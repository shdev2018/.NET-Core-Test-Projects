using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentList.Model;

namespace StudentList.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IEnumerable<Student> Students { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGet()
        {
            Students = await _db.Student.ToListAsync();
            Console.WriteLine(Students);
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var studentFromDb = await _db.Student.FindAsync(id);

            if (studentFromDb == null)
            {
                return NotFound();
            }

            _db.Student.Remove(studentFromDb);
            await _db.SaveChangesAsync();
            Message = "Student deleted successfully";
            return RedirectToPage();
        }
    }
}