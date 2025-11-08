using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Materia
{
    public int MateriaId { get; set; }
    [Required, StringLength(100)] public string NombreMateria { get; set; } = string.Empty;
    [StringLength(80)] public string? Docente { get; set; }

    public ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
}
