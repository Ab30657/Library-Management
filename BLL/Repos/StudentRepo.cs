using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repos
{
    public class StudentRepo:BaseRepo<Student>
    {
        public Student GetStudent(string uName)
        {
            return GetOne(Context.Students.Where(x => x.FullName == uName).Select(x => x.StudentId).FirstOrDefault());
        }

        public override List<Student> GetAll()
        {
            return base.GetAll().Where(x => x.HasCard == false).ToList();
        }
    }
}
