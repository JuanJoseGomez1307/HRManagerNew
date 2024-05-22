using HRManagerNew.Data;
using HRManagerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManagerNew.Pages.Departamentos
{
    public class EditModel : PageModel
    {
        private readonly HRManagerNewContext _contex;

        public EditModel(HRManagerNewContext contex)
        {
            _contex = contex;
        }
        [BindProperty]

        public Departamento Departamento { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _contex.Departamentos == null)
            {
                return NotFound();
            }

            var departamento = await _contex.Departamentos.FirstOrDefaultAsync(m => m.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }
            Departamento = departamento;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _contex.Attach(Departamento).State = EntityState.Modified;

            try
            {
                await _contex.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(Departamento.Id))
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

        private bool DepartamentoExists(int id)
        {
            return (_contex.Departamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
