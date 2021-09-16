using StudentManage.Models;
using StudentManage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Sevices.Interface
{
    public interface IStudent
    {
        // crud 
        IEnumerable<GetAllStudents> GetAll();
        Student GetByMssv(string mssv);
        void Insert(Student stu);
        void Delete(Student stu);
        void Update(Student stu);
     
        void Save();


    }
}
