using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class OfficialVacation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength =3,ErrorMessage ="The Name Must Be Between 3 and 50 characters")]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}