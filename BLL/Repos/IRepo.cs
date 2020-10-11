using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repos
{
    public interface IRepo<T>
    {
        //CRUD Users

        T GetOne(string uName);
    }
}
