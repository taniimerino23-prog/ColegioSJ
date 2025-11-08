using System.Linq;

public static class DbInitializer
{
    public static void Seed(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ColegioContext>();
        db.Database.EnsureCreated();
        if (db.Alumnos.Any()) return;

        var alumnos = new[] {
      new Alumno { Nombre = "Ana", Apellido = "López", Grado = "9°" },
      new Alumno { Nombre = "Carlos", Apellido = "Pérez", Grado = "10°" }
    };
        var materias = new[] {
      new Materia { NombreMateria = "Matemática", Docente = "Mtra. Ruiz" },
      new Materia { NombreMateria = "Lenguaje",   Docente = "Lic. Gómez" }
    };
        db.Alumnos.AddRange(alumnos);
        db.Materias.AddRange(materias);
        db.SaveChanges();

        db.Expedientes.AddRange(
          new Expediente { AlumnoId = alumnos[0].AlumnoId, MateriaId = materias[0].MateriaId, NotaFinal = 8.5m, Observaciones = "Buen desempeño" },
          new Expediente { AlumnoId = alumnos[0].AlumnoId, MateriaId = materias[1].MateriaId, NotaFinal = 7.9m },
          new Expediente { AlumnoId = alumnos[1].AlumnoId, MateriaId = materias[0].MateriaId, NotaFinal = 6.8m }
        );
        db.SaveChanges();
    }
}
