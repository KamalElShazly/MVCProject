using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    [Table("Students")]
    public class Student : ApplicationUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int DepartmentId { get; set; }
        //public virtual Department Dept { get; set; }
    }
}