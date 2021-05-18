using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Students.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Gender Gender { get; set; }


        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }
    }
}