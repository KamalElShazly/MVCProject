using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public enum CourseStatus { NotFinished, Finished }
    public class InstructorCourseDepartment
    {
        [Key, ForeignKey("Ins"), Required, Column(Order = 0)]
        public string InstructorId { get; set; }
        [Key, ForeignKey("Crs"), Required, Column(Order = 2)]
        public string CourseCode { get; set; }
        [Key, ForeignKey("Dept"), Required, Column(Order = 1)]
        public int DepartmentId { get; set; }
        [Required]
        public CourseStatus CourseStatus { get; set; }
        public virtual Instructor Ins { get; set; }
        public virtual Course Crs { get; set; }
        public virtual Department Dept { get; set; }
    }
}