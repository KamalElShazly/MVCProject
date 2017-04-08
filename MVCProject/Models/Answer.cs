using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Answer
    {
        [Key,ForeignKey("Qst"),Column(Order =0)]
        public int QuestionId { get; set; }
        [Key, Column(Order = 1)]
        public string Choice { get; set; }
        public virtual Question Qst { get; set; }
    }
}