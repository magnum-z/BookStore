using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        // ID book
        public int Id { get; set; }
        // name of book
        public string Name { get; set; }
        // author of book
        public string Author { get; set; }
        // price
        public int Price { get; set; }
    }
}