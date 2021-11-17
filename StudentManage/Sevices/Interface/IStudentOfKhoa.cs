using System;
using System.Collections.Generic;
using StudentManage.Models;
using System.Linq;
using System.Web;

namespace StudentManage.Sevices.Interface
{
    public interface IStudentOfKhoa
    {
        void Insert(int StudentID, int KhoaID);
        void Update(int StudentID, int KhoaID);
        void Delete(int studentId);
        StudentOfKhoa GetByID(int Id);
        void Save();
        StudentOfKhoa GetByStudentID(int StudentId);
        void DeleteMSSV(int IDmssv);
    }
}