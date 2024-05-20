using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly HRManagerNewContext _context;

        public IndexModel(HRManagerNewContext context)
        {
            _context = context;
        }

        public IList<Empleado> Empleados { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Empleados != null)
            {
                Empleados = await _context.Empleados.ToListAsync();
            }
        }
    }
}
