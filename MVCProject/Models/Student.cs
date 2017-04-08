using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    [Table("Students")]
    public class Student : ApplicationUser
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name Must Be Between 3 and 50 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name Must Be Between 3 and 50 characters")]
        public string LastName { get; set; }
        [ForeignKey("Dept")]
        public int DepartmentId { get; set; }
        public virtual Department Dept { get; set; }
    }
}