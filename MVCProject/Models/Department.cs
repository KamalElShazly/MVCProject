﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{

    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name Must Be Between 2 and 50 characters")]
        public string Name { get; set; }
        
        [Range(20,50)]
        public int Capacity { get; set; }

        public List<Course> Courses { get; set; }

        [Required]
        [ForeignKey("Ins")]
        public string ManagerId { get; set; }

        [InverseProperty("Dept")]
        public List<Instructor> instrucs { get; set; }
        public virtual Instructor Ins { get; set; }

    }
}