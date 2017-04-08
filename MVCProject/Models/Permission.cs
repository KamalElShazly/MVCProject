using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MVCProject.Models
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("std")]
        public string StudentId { get; set; }

        public virtual Student std { get; set; }


    }
}