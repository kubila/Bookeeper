using Booky.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.ViewModels
{
    public class BookViewModel
    {
        public int Book_Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(15)]
        public string ISBN { get; set; }

        [Required]
        public double Price { get; set; }

        
        public int Category_Id { get; set; } 
        public Category Category { get; set; }

        
        public int BookDetail_Id { get; set; }
        public BookDetail BookDetail { get; set; }

        
        public int Publisher_Id { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
