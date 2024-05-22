using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManagerNew.Pages.Cargos
{
    public class CreateModel : PageModel
    {
        private readonly HRManagerNewContext _context;

        public CreateModel(HRManagerNewContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]

        public Cargo Cargo { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Cargos == null || Cargo == null)
            {
                return Page();
            }

            _context.Cargos.Add(Cargo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
