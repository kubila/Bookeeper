using Booky.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.ViewModels
{
    public class AuthorViewModel
    {        

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
       
        public string FullName
        {
            get
            {
                return $"{FirstName} + {LastName}";
            }
        }
        
    }
}
