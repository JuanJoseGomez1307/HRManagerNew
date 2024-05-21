using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Pages.Nominas
{
    public class EditModel : PageModel
    {
        private readonly HRManagerNewContext _context;

        public EditModel(HRManagerNewContext context)
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
            Nomina = nomina;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Nomina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NominaExists(Nomina.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NominaExists(int id)
        {
            return (_context.Nominas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
