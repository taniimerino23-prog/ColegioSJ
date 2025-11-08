using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColegioSJ.Models;   

namespace ColegioSJ.Controllers
{
    public class ReportesController : Controller
    {
        private readonly ColegioContext _db;

        public ReportesController(ColegioContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> PromedioPorAlumno()
        {
            var data = await _db.Expedientes
                .Include(e => e.Alumno)
                .Where(e => e.NotaFinal != null)
                .GroupBy(e => new { e.AlumnoId, e.Alumno!.Nombre, e.Alumno!.Apellido })
                .Select(g => new PromedioAlumnoVM
                {
                    AlumnoId = g.Key.AlumnoId,
                    Alumno = (g.Key.Nombre + " " + g.Key.Apellido).Trim(),
                    Promedio = g.Average(x => x.NotaFinal)   // notas promedio
                })
                .OrderBy(x => x.Alumno)
                .ToListAsync();

            return View(data);
        }
    }
}
