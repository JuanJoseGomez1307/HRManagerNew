using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Pages.Cargos
{
    public class IndexModel : PageModel
    {
        private readonly HRManagerNewContext _context;

        public IndexModel(HRManagerNewContext context)
        {
            _context = context;
        }

        public IList<Cargo> Cargos { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Beneficios != null)
            {
                Cargos = await _context.Cargos.ToListAsync();
            }
        }

    }
}
