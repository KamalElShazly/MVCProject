using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public enum InstructorStatus { Internal,External}
    [Table("Instructors")]
    public class Instructor:ApplicationUser
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name Must Be Between 3 and 50 characters")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime GraduationYear { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Qualification Must Be Between 3 and 50 characters")]
        public string Qualification { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public InstructorStatus Status => DepartmentId == null ? InstructorStatus.External : InstructorStatus.Internal;
        [ForeignKey("Dept")]
        public int? DepartmentId { get; set; }
        public virtual Department Dept { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}