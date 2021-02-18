using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vaida_Cecilia_Proiect.Data;
using Vaida_Cecilia_Proiect.Models;

namespace Vaida_Cecilia_Proiect.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Vaida_Cecilia_Proiect.Data.Vaida_Cecilia_ProiectContext _context;

        public IndexModel(Vaida_Cecilia_Proiect.Data.Vaida_Cecilia_ProiectContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
