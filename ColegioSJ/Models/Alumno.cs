using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Alumno {
    public int AlumnoId { get; set; }

    [Required, StringLength(80)] public string Nombre { get; set; } = string.Empty;
    [Required, StringLength(80)] public string Apellido { get; set; } = string.Empty;
    [DataType(DataType.Date)] public DateTime? FechaNacimiento { get; set; }
    [StringLength(30)] public string? Grado { get; set; }

    public ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
    public string NombreCompleto => $"{Nombre} {Apellido}".Trim();
}
