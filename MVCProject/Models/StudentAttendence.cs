using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class StudentAttendence
    {
        [Key, Column(Order = 0)]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Required]
        [Key, ForeignKey("Std"),Column(Order =1)]
        public string StudentId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LeavingTime { get; set; }
        public virtual Student Std { get; set; }
    }
}