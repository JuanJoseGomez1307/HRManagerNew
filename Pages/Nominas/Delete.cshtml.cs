using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Pages.Nominas
{
    public class DeleteModel : PageModel
    {
        private readonly HRManagerNewContext _context;

        public DeleteModel(HRManagerNewContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Nomina Nomina { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Nominas == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nominas.FirstOrDefaultAsync(m => m.Id == id);

            if (nomina == null)
            {
                return NotFound();
            }
            else
            {
                Nomina = nomina;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Nominas == null)
            {
                return NotFound();
            }
            var nomina = await _context.Nominas.FindAsync(id);

            if (nomina != null)
            {
                Nomina = nomina;
                _context.Nominas.Remove(Nomina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
