using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarList.Pages.Shared
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AddModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Guitar Guitar { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult>OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Guitar.Add(Guitar);
            await _db.SaveChangesAsync();
            Message = "Guitar added successfully";
            return RedirectToPage("Index");
        }
    }
}