using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STIThesisPortal_c.Data;
using STIThesisPortal_c.Model;

namespace STIThesisPortal_c.Pages.ThesisPages
{
    public class EditModel : PageModel
    {
        private readonly STIThesisPortal_c.Data.ThesisContext _context;

        public EditModel(STIThesisPortal_c.Data.ThesisContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ThesisModel ThesisModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ThesisModel == null)
            {
                return NotFound();
            }

            var thesismodel =  await _context.ThesisModel.FirstOrDefaultAsync(m => m.accession == id);
            if (thesismodel == null)
            {
                return NotFound();
            }
            ThesisModel = thesismodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ThesisModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThesisModelExists(ThesisModel.accession))
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

        private bool ThesisModelExists(string id)
        {
          return (_context.ThesisModel?.Any(e => e.accession == id)).GetValueOrDefault();
        }
    }
}
