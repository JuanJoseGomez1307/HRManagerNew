using HRManagerNew.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Data
{
    public class HRManagerNewContext: DbContext
    {
        public HRManagerNewContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Nomina> Nominas { get; set; }
        public DbSet<Beneficio> Beneficios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=HRManagerNew;Trusted_Connection=True;");
        }
    }
}
