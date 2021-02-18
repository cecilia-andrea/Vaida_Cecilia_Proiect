using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vaida_Cecilia_Proiect.Data;
using Vaida_Cecilia_Proiect.Models;

namespace Vaida_Cecilia_Proiect.Pages.Cars
{
    public class EditModel : CarCategoriesPageModel
    {
        private readonly Vaida_Cecilia_Proiect.Data.Vaida_Cecilia_ProiectContext _context;

        public EditModel(Vaida_Cecilia_Proiect.Data.Vaida_Cecilia_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.Include(b => b.Publisher).Include(b => b.CarCategories).ThenInclude(b => b.Category).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Car == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Car);
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        /*public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }*/

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carToUpdate = await _context.Car.Include(i => i.Publisher).Include(i => i.CarCategories).ThenInclude(i => i.Category).FirstOrDefaultAsync(s => s.ID == id);
            if (carToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Car>(carToUpdate, "Car", i => i.Marca, i => i.Model, i => i.Pret, i => i.PublishingDate, i => i.Publisher))
            {
                UpdateCarCategories(_context, selectedCategories, carToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateCarCategories(_context, selectedCategories, carToUpdate);
            PopulateAssignedCategoryData(_context, carToUpdate);
            return Page();
        }
    }


          /*  private bool CarExists(int id)
            {
                return _context.Car.Any(e => e.ID == id);
            }*/
        
    
}