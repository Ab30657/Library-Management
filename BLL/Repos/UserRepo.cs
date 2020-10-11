using BLL.EF;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BLL.Repos
{
    public class UserRepo:BaseRepo<User>
    {
        public UserRepo(LibraryContext context):base(context)
        {
            
        }

    }
}
