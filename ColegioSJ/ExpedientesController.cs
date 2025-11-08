using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ColegioSJ
{
    public class ExpedientesController : Controller
    {
        private readonly ColegioContext _context;

        public ExpedientesController(ColegioContext context)
        {
            _context = context;
        }

       
        private void CargarCombos(int? alumnoId = null, int? materiaId = null)
        {
            ViewBag.AlumnoId = new SelectList(
                _context.Alumnos
                    .AsNoTracking()
                    .OrderBy(a => a.Apellido)
                    .ThenBy(a => a.Nombre)
                    .ToList(),
                "AlumnoId", "NombreCompleto", alumnoId
            );

            ViewBag.MateriaId = new SelectList(
                _context.Materias
                    .AsNoTracking()
                    .OrderBy(m => m.NombreMateria)
                    .ToList(),
                "MateriaId", "NombreMateria", materiaId
            );
        }

        
        public async Task<IActionResult> Index()
        {
            var lista = _context.Expedientes
                .AsNoTracking()
                .Include(e => e.Alumno)
                .Include(e => e.Materia);

            return View(await lista.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var expediente = await _context.Expedientes
                .AsNoTracking()
                .Include(e => e.Alumno)
                .Include(e => e.Materia)
                .FirstOrDefaultAsync(m => m.ExpedienteId == id);

            if (expediente == null) return NotFound();

            return View(expediente);
        }

        
        public IActionResult Create()
        {
            CargarCombos();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpedienteId,AlumnoId,MateriaId,NotaFinal,Observaciones")] Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            CargarCombos(expediente.AlumnoId, expediente.MateriaId);
            return View(expediente);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var expediente = await _context.Expedientes.FindAsync(id);
            if (expediente == null) return NotFound();

            CargarCombos(expediente.AlumnoId, expediente.MateriaId);
            return View(expediente);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpedienteId,AlumnoId,MateriaId,NotaFinal,Observaciones")] Expediente expediente)
        {
            if (id != expediente.ExpedienteId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpedienteExists(expediente.ExpedienteId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            CargarCombos(expediente.AlumnoId, expediente.MateriaId);
            return View(expediente);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var expediente = await _context.Expedientes
                .AsNoTracking()
                .Include(e => e.Alumno)
                .Include(e => e.Materia)
                .FirstOrDefaultAsync(m => m.ExpedienteId == id);

            if (expediente == null) return NotFound();

            return View(expediente);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);
            if (expediente != null)
            {
                _context.Expedientes.Remove(expediente);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        
        private bool ExpedienteExists(int id)
        {
            return _context.Expedientes.Any(e => e.ExpedienteId == id);
        }
    }
}
