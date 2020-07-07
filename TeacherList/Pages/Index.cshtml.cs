using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeacherList.Model;

namespace TeacherList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Teacher> Teachers { get; set; }

        [BindProperty]
        [TempData]
        public string Message { get; set; }


        public async Task OnGet()
        {
            Teachers = await _db.Teacher.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var teacherFromDb = await _db.Teacher.FindAsync(id);

            if (teacherFromDb == null)
            {
                return NotFound();
            }

            _db.Teacher.Remove(teacherFromDb);
            await _db.SaveChangesAsync();
            Message = "Teacher deleted successfully";
            return RedirectToPage("Index");

        }

    }
}