using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagerNew.Models
{
    public class Nomina
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime PeriodoInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime PeriodoFin { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPagado { get; set; }

        public int EmpleadoId { get; set; }
        public Empleado? Empleado { get; set; } = default!;
    }
}
