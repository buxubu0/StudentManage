using System;
using System.Collections.Generic;
using System.Linq;
using StudentManage.Models;
using System.Web;
using StudentManage.ViewModels.ClassViewModels;
using StudentManage.ViewModels.StudentViewModels;

namespace StudentManage.Sevices.Interface
{
    public interface IClass
    {
        IEnumerable<Class> GetAllClass();
        void Insert(Class lop);
       
        void Delete(int IdClass);
        void Save();
        bool CheckMa (string ma);
       
        Class GetByID(int id);
        void UpdateClass(EditClass model);
        int CheckTeacher(int checkTeacherId);
    }
}