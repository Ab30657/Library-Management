using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Book
    {
        public Book()
        {

        }
        public int BookId { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public bool IsRef { get; set; }

        public int AdminId { get; set; }  //One who added the book

        public byte[] Image { get; set; }

        public string Author { get; set; }

        public DateTime AddedDate { get; set; }

    }
}
