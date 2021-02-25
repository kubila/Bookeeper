using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Booky.Models
{
    public class Author
    {
        [Key]
        public int Author_Id { get; set; }

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

        [NotMapped]
        public string FullName { 
            get
            {
                return $"{FirstName} + {LastName}";
            }
        }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
