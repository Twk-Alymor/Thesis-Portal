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
    public class IndexModel : PageModel
    {
        private readonly STIThesisPortal_c.Data.ThesisContext _context;

        public IndexModel(STIThesisPortal_c.Data.ThesisContext context)
        {
            _context = context;
        }

        public IList<ThesisModel> ThesisModel { get;set; } = default!;

        public async Task OnGetAsync(String SearchString, int SearchYear)
        {
            if (_context.ThesisModel != null)
            {
                var theses = from t in _context.ThesisModel
                             select t;

                // *** Filtering the record
                if (!String.IsNullOrEmpty(SearchString))
                {
                    theses = _context.ThesisModel.Where(th => th.title!.Contains(SearchString) || th.author!.Contains(SearchString));
                }

                /*
                if (SearchYear != null) {
                    theses = _context.ThesisModel.Where(th => th.year == SearchYear);
                }
                */

                ThesisModel = await theses.ToListAsync();
            }
        }
    }
}
