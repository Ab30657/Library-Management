using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FullName { get; set; }
        
        public string Gender { get; set; }

        public bool HasCard { get; set; }

        public virtual Card Card { get; set; }
    }
}
