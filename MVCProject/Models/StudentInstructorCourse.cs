using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class StudentInstructorCourse
    {
        [Key,ForeignKey("Std"),Required,Column(Order =0)]
        public string StudentId { get; set; }
        [Key, ForeignKey("Ins"), Required, Column(Order = 1)]
        public string InstructorId { get; set; }
        [Key, ForeignKey("Crs"), Required, Column(Order = 2)]
        public string CourseCode { get; set; }
        [Range(0,5,ErrorMessage = "Evaluation must be between 0 and 5")]
        public int InstructorEvaluation { get; set; }
        [Range(0, 40, ErrorMessage = "Lab Grade must be between 0 and 40")]
        public float LabGrade { get; set; }
        public virtual Student Std { get; set; }
        public virtual Instructor Ins { get; set; }
        public virtual Course Crs { get; set; }
    }
}