using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        Student=1,
        Admin=2
    }
}
