using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repos
{
    public interface IRepo<T>
    {
        //CRUD Users
        int Add(T entity);
        int Update(T entity);
        int Delete(int id);
        int Delete(T entity);

        T GetOne(int? id);
    }
}
