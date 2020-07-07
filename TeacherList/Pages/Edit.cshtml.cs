using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeacherList.Model;

namespace TeacherList.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Teacher Teacher { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGet(int id)
        {
            Teacher = await _db.Teacher.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }

            var teacherFromDb = await _db.Teacher.FindAsync(Teacher.id);

            teacherFromDb.FirstName = Teacher.FirstName;
            teacherFromDb.LastName = Teacher.LastName;
            teacherFromDb.Instrument = Teacher.Instrument;

            await _db.SaveChangesAsync();
            Message = "Teacher info updated successfully";
            return RedirectToPage("Index");
        }
    }
}