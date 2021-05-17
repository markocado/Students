using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Students.Models
{
    public class Gender
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public static string Male = "Male";

        public static string Female = "Female";
    }
}