using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Booky.Models
{
    public class Book
    {
        [Key]
        
        public int Book_Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(15)]
        public string ISBN { get; set; }

        [Required]
        public double Price { get; set; }

        [ForeignKey("Category")]
        public int Category_Id { get; set; } // if these navigation properties added, ef core going to map these as "Cascade" on "UPDATE" and "DELETE"
        public Category Category { get; set; }

        [ForeignKey("BookDetail")]
        public int BookDetail_Id { get; set; } // if these navigation properties added, ef core going to map these as "Cascade" on "UPDATE" and "DELETE"
        public BookDetail BookDetail { get; set; }

        [ForeignKey("Publisher")]
        public int Publisher_Id { get; set; } // if these navigation properties added, ef core going to map these as "Cascade" on "UPDATE" and "DELETE"
        public Publisher Publisher { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }

    }
}
