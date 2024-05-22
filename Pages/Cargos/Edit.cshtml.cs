using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Pages.Cargos
{
    public class EditModel : PageModel
    {
        private readonly HRManagerNewContext _contex;

        public EditModel(HRManagerNewContext contex)
        {
            _contex = contex;
        }
        [BindProperty]

        public Cargo Cargo { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _contex.Cargos == null)
            {
                return NotFound();
            }

            var cargo = await _contex.Cargos.FirstOrDefaultAsync(m => m.Id == id);
            if (cargo == null)
            {
                return NotFound();
            }
            Cargo = cargo;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _contex.Attach(Cargo).State = EntityState.Modified;

            try
            {
                await _contex.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(Cargo.Id))
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

        private bool CargoExists(int id)
        {
            return (_contex.Cargos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
