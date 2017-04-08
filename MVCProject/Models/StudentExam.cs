using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class StudentExam
    {
        [Key, ForeignKey("Std"), Required, Column(Order =0)]
        public string StudentId { get; set; }

        [Key, ForeignKey("Ex"),Column(Order =1)]
        public int ExamId { get; set; }

        [Required,Range(0, 60, ErrorMessage = "Exam Grade must be between 0 and 60")]
        public float ExamGrade { get; set; }

        public virtual Student Std { get; set; }

        public virtual Exam Ex { get; set; }


    }
}