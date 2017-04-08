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
        [Key,ForeignKey("Std")]
        public int StudentId { get; set; }

        [Key, ForeignKey("Ex ")]
        public int ExamId { get; set; }

        [Required]
        public float Grade { get; set; }

      //  public virtual Student Std { get; set; }

       // public virtual Exam Ex { get; set; }


    }
}