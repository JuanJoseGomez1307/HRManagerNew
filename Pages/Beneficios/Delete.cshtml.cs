using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Pages.Beneficios
{
    public class DeleteModel : PageModel
    {
        private readonly HRManagerNewContext _context;

        public DeleteModel(HRManagerNewContext context)
        {
            _context = context;
        }
        [BindProperty]

        public Beneficio Beneficio { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Beneficios == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficios.FirstOrDefaultAsync(m => m.Id == id);

            if (beneficio == null)
            {
                return NotFound();
            }
            else
            {
                Beneficio = beneficio;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Beneficios == null)
            {
                return NotFound();
            }
            var beneficio = await _context.Beneficios.FindAsync(id);

            if (beneficio != null)
            {
                Beneficio = beneficio;
                _context.Beneficios.Remove(Beneficio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
