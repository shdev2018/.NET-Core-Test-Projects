using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentList.Model
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name="Last Name")]
        public string lastName { get; set; }

        [Phone]
        [Display(Name="Phone Number")]
        public string phoneNumber { get; set; }
    }
}
