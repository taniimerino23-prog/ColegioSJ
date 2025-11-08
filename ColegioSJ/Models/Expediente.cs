using System.ComponentModel.DataAnnotations;

public class Expediente
{
    public int ExpedienteId { get; set; }

    [Required] public int AlumnoId { get; set; }
    [Required] public int MateriaId { get; set; }

    [Range(0, 10)] public decimal? NotaFinal { get; set; }   // cambia a 0–100 si tu rubrica lo pide
    [StringLength(300)] public string? Observaciones { get; set; }

    public Alumno? Alumno { get; set; }
    public Materia? Materia { get; set; }
}
