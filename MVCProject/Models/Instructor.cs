using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    [Table("Instructors")]
    public class Instructor:ApplicationUser
    {
        public string Name { get; set; }
        public DateTime GraduationYear { get; set; }
        public string Qualification { get; set; }
        //public int DepartmentId { get; set; }
        //public virtual Department Dept { get; set; }
    }
}