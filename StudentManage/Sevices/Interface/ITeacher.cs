using System;
using System.Collections.Generic;
using System.Linq;
using StudentManage.Models;
using System.Web;

namespace StudentManage.Sevices.Interface
{
    public interface ITeacher
    {
        IEnumerable<Teacher> GetAllTeacher();
        void Insert(Teacher gv);
        void Update(Teacher gv);
        void Delete(Teacher IdTeacher);
        void Save();
        Teacher GetIDTeacher(int id);
    }
}