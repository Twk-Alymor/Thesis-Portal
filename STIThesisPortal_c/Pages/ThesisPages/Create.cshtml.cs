using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using STIThesisPortal_c.Data;
using STIThesisPortal_c.Model;

namespace STIThesisPortal_c.Pages.ThesisPages
{
    public class CreateModel : PageModel
    {
        private readonly STIThesisPortal_c.Data.ThesisContext _context;

        public CreateModel(STIThesisPortal_c.Data.ThesisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ThesisModel ThesisModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ThesisModel == null || ThesisModel == null)
            {
                return Page();
            }

            _context.ThesisModel.Add(ThesisModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
