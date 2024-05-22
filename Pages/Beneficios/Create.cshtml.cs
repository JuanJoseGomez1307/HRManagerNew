using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManagerNew.Pages.Beneficios
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

        public Beneficio Beneficio { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Beneficios == null || Beneficio == null)
            {
                return Page();
            }

            _context.Beneficios.Add(Beneficio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
