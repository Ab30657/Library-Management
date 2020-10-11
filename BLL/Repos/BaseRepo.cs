using BLL.EF;
using BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BLL.Repos
{
    public class BaseRepo<T> :IDisposable, IRepo<T> where T : User, new()
    {
        private readonly DbSet<T> _table;
        private readonly LibraryContext _db;
        protected LibraryContext Context => _db;
        public BaseRepo():this(new LibraryContext())
        {

        }

        public BaseRepo(LibraryContext context)
        {
            _db = context;
            _table = _db.Set<T>();
        }
        public void Dispose()
        {
            _db?.Dispose();
        }

        public T GetOne(string uName)
        {
            return _table.Find(_db.Users.Where(x=>x.Username==uName).Select(x=>x.UserId).FirstOrDefault());
        }

        internal int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
