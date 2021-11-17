using System;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.Sevices.Interface
{
    public interface IStudentJoinYear
    {
        void Insert(int StudentId, int YearId);
        void Update(int StudentId, int YearId);
        StudentJoinYear GetByID(int Id);
        void Save();
        void Delete(int studentID );
        StudentJoinYear GetByStudentID(int studentId);
        void DeleteMSSV(int IDMSSV);




    }
}