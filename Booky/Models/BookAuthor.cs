using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Booky.Models
{
    public class BookAuthor
    {
        [ForeignKey("Book")]
        public int Book_Id { get; set; } // if these navigation properties added, ef core going to map these as "Cascade" on "UPDATE" and "DELETE"

        [ForeignKey("Author")]
        public int Author_Id { get; set; } // if these navigation properties added, ef core going to map these as "Cascade" on "UPDATE" and "DELETE"

        public Book Book { get; set; }

        public Author Author { get; set; }
    }
}
