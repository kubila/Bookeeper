using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Booky.Models
{
    public class Category
    {
        [Key] // set the key with DataAnnotations
        public int Category_Id { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
