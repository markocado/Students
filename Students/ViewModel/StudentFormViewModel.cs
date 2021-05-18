using Students.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Students.ViewModel
{
    public class StudentFormViewModel
    {

        public string Title { 
            get
            {
                if (this.Student == null || this.Student.Id == 0)
                    return "New";
                else
                    return "Edit";
            }
        }
        public Student Student { get; set; }
        public int GenderId { get; set; }
        public List<Gender> Genders { get; set; }
    }
}