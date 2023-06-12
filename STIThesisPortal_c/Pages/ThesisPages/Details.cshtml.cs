using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using STIThesisPortal_c.Data;
using STIThesisPortal_c.Model;

namespace STIThesisPortal_c.Pages.ThesisPages
{
    public class DetailsModel : PageModel
    {
        private readonly STIThesisPortal_c.Data.ThesisContext _context;

        public DetailsModel(STIThesisPortal_c.Data.ThesisContext context)
        {
            _context = context;
        }

      public ThesisModel ThesisModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ThesisModel == null)
            {
                return NotFound();
            }

            var thesismodel = await _context.ThesisModel.FirstOrDefaultAsync(m => m.accession == id);
            if (thesismodel == null)
            {
                return NotFound();
            }
            else 
            {
                ThesisModel = thesismodel;
            }
            return Page();
        }
    }
}
