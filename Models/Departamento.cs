namespace HRManagerNew.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public ICollection<Empleado>? Empleado { get; set; } = default!;
    }
}
