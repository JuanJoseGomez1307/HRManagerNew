namespace HRManagerNew.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        public string TituloCargo { get; set; }
        public string? Descripcion { get; set; }
        public ICollection<Empleado>? Empleado { get; set; } = default!;
    }
}
