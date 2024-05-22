using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Pages.Beneficios
{
    public class EditModel : PageModel
    {
        private readonly HRManagerNewContext _contex;

        public EditModel(HRManagerNewContext contex)
        {
            _contex = contex;
        }
        [BindProperty]

        public Beneficio Beneficio { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _contex.Beneficios == null)
            {
                return NotFound();
            }

            var beneficio = await _contex.Beneficios.FirstOrDefaultAsync(m => m.Id == id);
            if (beneficio == null)
            {
                return NotFound();
            }
            Beneficio = beneficio;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _contex.Attach(Beneficio).State = EntityState.Modified;

            try
            {
                await _contex.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficioExists(Beneficio.Id))
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

        private bool BeneficioExists(int id)
        {
            return (_contex.Beneficios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
