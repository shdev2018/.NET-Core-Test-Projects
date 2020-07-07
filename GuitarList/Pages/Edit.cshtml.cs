using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarList.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Guitar Guitar { get; set; }

        public async Task OnGet(int id)
        {
            Guitar = await _db.Guitar.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                var guitarFromDb = await _db.Guitar.FindAsync(Guitar.id);
                guitarFromDb.Make = Guitar.Make;
                guitarFromDb.Model = Guitar.Model;

                await _db.SaveChangesAsync();
                Message = "Guitar updated successfully";
                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }

    }
}