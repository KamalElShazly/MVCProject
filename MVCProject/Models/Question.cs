using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }

        public virtual List<Answer> Answers { get; set; }
        public virtual List<Exam> Exams { get; set; }
    }
}