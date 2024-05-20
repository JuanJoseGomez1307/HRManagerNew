using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagerNew.Models
{
    public class Beneficio
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostoEmpresa { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostoEmpleado { get; set; }
    }
}
