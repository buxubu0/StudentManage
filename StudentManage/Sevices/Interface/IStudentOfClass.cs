using System;
using System.Collections.Generic;
using System.Linq;
using StudentManage.Models;
using System.Web;

namespace StudentManage.Sevices.Interface
{
    public interface IStudentOfClass
    {
        void Insert(int Studentid, int Classid);
        void Update(int Studentid, int Classid);
        void Delete(int Studentid);

        StudentOfClasss GetByStudentID(int studentId);
        void DeleteMSSV(int mssv);
        void save();
    }
}