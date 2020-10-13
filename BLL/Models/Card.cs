using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Card
    {
        public int CardId { get; set; }

        public string CardNum { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
