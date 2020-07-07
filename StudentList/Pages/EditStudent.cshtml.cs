using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentList.Model;

namespace StudentList.Pages
{
    public class EditStudentModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public EditStudentModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGet(int id)
        {
            Student = await _db.Student.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("index");
            }

            var studentFromDb = await _db.Student.FindAsync(Student.id);

            studentFromDb.firstName = Student.firstName;
            studentFromDb.lastName = Student.lastName;
            studentFromDb.phoneNumber = Student.phoneNumber;

            await _db.SaveChangesAsync();
            Message = "Student info updated sucessfully.";
            return RedirectToPage("Index");

        }
    }
}