using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagerNew.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaContratacion { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; } = default!;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salario { get; set; }
        public int CargoId { get; set; }
        public Cargo? Cargo { get; set; } = default!;
        public ICollection<Nomina>? Nomina { get; set; } = default!;
    }
}
