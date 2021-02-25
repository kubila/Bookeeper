using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Booky.Models
{
    public class BookGenre
    {

        [ForeignKey("Book")]
        public int Book_Id { get; set; }

        [ForeignKey("Genre")]
        public int Genre_Id { get; set; }

        public Book Book { get; set; }

        public Genre Genre { get; set; }
    }
}
