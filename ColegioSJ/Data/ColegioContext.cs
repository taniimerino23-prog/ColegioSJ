using Microsoft.EntityFrameworkCore;

public class ColegioContext : DbContext
{
    public ColegioContext(DbContextOptions<ColegioContext> options) : base(options) { }

    public DbSet<Alumno> Alumnos => Set<Alumno>();
    public DbSet<Materia> Materias => Set<Materia>();
    public DbSet<Expediente> Expedientes => Set<Expediente>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);

        mb.Entity<Alumno>().HasIndex(a => new { a.Nombre, a.Apellido });
        mb.Entity<Materia>().HasIndex(m => m.NombreMateria);

        mb.Entity<Expediente>()
            .HasOne(e => e.Alumno).WithMany(a => a.Expedientes)
            .HasForeignKey(e => e.AlumnoId).OnDelete(DeleteBehavior.Cascade);

        mb.Entity<Expediente>()
            .HasOne(e => e.Materia).WithMany(m => m.Expedientes)
            .HasForeignKey(e => e.MateriaId).OnDelete(DeleteBehavior.Cascade);

        // Un Alumno no puede tener dos expedientes de la misma Materia
        mb.Entity<Expediente>()
          .HasIndex(e => new { e.AlumnoId, e.MateriaId })
          .IsUnique();
    }
}
