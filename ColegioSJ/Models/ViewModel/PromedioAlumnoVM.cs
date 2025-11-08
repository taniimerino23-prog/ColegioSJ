namespace ColegioSJ.Models;

public class PromedioAlumnoVM
{
    public int AlumnoId { get; set; }
    public string Alumno { get; set; } = string.Empty;
    public decimal? Promedio { get; set; }
}
