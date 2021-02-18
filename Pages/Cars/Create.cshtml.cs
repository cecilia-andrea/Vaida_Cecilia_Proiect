using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vaida_Cecilia_Proiect.Data;
using Vaida_Cecilia_Proiect.Models;

namespace Vaida_Cecilia_Proiect.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly Vaida_Cecilia_Proiect.Data.Vaida_Cecilia_ProiectContext _context;

        public CreateModel(Vaida_Cecilia_Proiect.Data.Vaida_Cecilia_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher > (), "ID", "PublisherName");
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
