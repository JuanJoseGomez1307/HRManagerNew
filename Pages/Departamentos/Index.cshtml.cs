using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Pages.Departamentos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HRManagerNewContext _context;

        public IndexModel(HRManagerNewContext context)
        {
            _context = context;
        }

        public IList<Departamento> Departamentos { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Departamentos != null)
            {
                Departamentos = await _context.Departamentos.ToListAsync();
            }
        }
    }
}
