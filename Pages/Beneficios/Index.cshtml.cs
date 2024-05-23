using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Pages.Beneficios
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HRManagerNewContext _context;

        public IndexModel(HRManagerNewContext context)
        {
            _context = context;
        }

        public IList<Beneficio> Beneficios { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Beneficios != null)
            {
                Beneficios = await _context.Beneficios.ToListAsync();
            }
        }
    }
}
