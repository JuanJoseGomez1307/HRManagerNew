using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Pages.Nominas
{
    public class IndexModel : PageModel
    {
        private readonly HRManagerNewContext _context;

        public IndexModel(HRManagerNewContext context)
        {
            _context = context;
        }

        public IList<Nomina> Nominas { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Nominas != null)
            {
                Nominas = await _context.Nominas.ToListAsync();
            }
        }
    }
}
