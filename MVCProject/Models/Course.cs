using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Course
    {
        [Key]
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Code must be between 3 and 10 characters")]
        public string Code { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }
        [Range(1, 6, ErrorMessage = "Lecture Duartion must be between 1 and 6")]
        public int LectureDuartion { get; set; }
        [Range(1, 6, ErrorMessage = "Lab Duartion must be between 1 and 6")]
        public int LabDuration { get; set; }
        public virtual List<Instructor> Instructors { get; set; }
        public virtual List<Department> Departments { get; set; }
        public virtual List<Exam> Exams { get; set; }

    }
}