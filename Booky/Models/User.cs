using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.Models
{
    public class User : IdentityUser
    {

        [StringLength(50, ErrorMessage = "First Name must be minium 5 characters and maximum 50 characters."), MinLength(5)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last Name must be minium 5 characters and maximum 50 characters."), MinLength(5)]        
        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} + {LastName}";
            }
        }
    }
}
