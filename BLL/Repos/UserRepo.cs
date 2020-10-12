using BLL.EF;
using BLL.Models;
using System.Linq;

namespace BLL.Repos
{
    public class UserRepo:BaseRepo<User>
    {
        public UserRepo():base()
        {
            
        }

        public User GetUser(string uName)
        {
            return GetOne(Context.Users.Where(x => x.Username == uName).Select(x => x.UserId).FirstOrDefault());
        }

    }
}
