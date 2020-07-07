using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentList.Model;

namespace StudentList.Pages
{
    public class AddStudentModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public AddStudentModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Student.Add(Student);
            await _db.SaveChangesAsync();
            Message = "Student Added Successfully";
            return RedirectToPage("Index");
        }
    }
}