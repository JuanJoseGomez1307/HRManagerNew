using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Pages.Cargos
{
    public class DeleteModel : PageModel
    {
        private readonly HRManagerNewContext _context;

        public DeleteModel(HRManagerNewContext context)
        {
            _context = context;
        }
        [BindProperty]

        public Cargo Cargo { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cargos == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos.FirstOrDefaultAsync(m => m.Id == id);

            if (cargo == null)
            {
                return NotFound();
            }
            else
            {
                Cargo = cargo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cargos == null)
            {
                return NotFound();
            }
            var cargo = await _context.Cargos.FindAsync(id);

            if (cargo != null)
            {
                Cargo = cargo;
                _context.Cargos.Remove(Cargo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
