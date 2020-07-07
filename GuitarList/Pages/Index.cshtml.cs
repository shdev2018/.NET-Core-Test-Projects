using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GuitarList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Guitar> Guitars { get; set; }

        [BindProperty]
        [TempData]
        public string Message { get; set; }

        public async Task OnGet()
        {
            Guitars = await _db.Guitar.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var guitarFromDb = await _db.Guitar.FindAsync(id);

            if(guitarFromDb == null)
            {
                return NotFound();
            }

            _db.Guitar.Remove(guitarFromDb);
            await _db.SaveChangesAsync();
            Message = "Guitar Deleted Successfully";
            return RedirectToPage("Index");
        }
    }
}
