using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STIThesisPortal_c.Model;

namespace STIThesisPortal_c.Data
{
    public class ThesisContext : DbContext
    {
        public ThesisContext (DbContextOptions<ThesisContext> options)
            : base(options)
        {
        }

        public DbSet<STIThesisPortal_c.Model.ThesisModel> ThesisModel { get; set; } = default!;
    }
}
