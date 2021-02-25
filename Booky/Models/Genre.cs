using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Booky.Models
{
    [Table("tb_Genre")]
    public class Genre
    {
        public int GenreId { get; set; }

        [Column("Name")]
        public string GenreName { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
