using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MVCProject.Models
{
    [Table("Exam")]
    public class Exam
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(5,MinimumLength =3,ErrorMessage = "Subject Must Be Between 3 and 50 characters")]
        public string  Subject { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime From { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime To { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public TimeSpan Duration => To - From;

        [Required]
        [ForeignKey("Crs")]
        public string CourseCode { get; set; }
        public virtual Course Crs { get; set; }
        public virtual List<Question> Questions { get; set; }


    }
}