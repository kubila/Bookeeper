using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Booky.Models
{
    public class BookDetail
    {
        [Key]
        public int BookDetail_Id { get; set; }

        [Required]
        public int NumberOfPages { get; set; }

        [Required]
        public int NumberOfChapters { get; set; }

        public double Weight { get; set; }

        public Book Book { get; set; }
    }
}
