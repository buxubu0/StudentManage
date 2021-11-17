using StudentManage.Models;
using StudentManage.ViewModels;
using StudentManage.ViewModels.StudentViewModels;
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
        Student GetByID(int Id);
        void Insert(Student stu);
        void Delete(int IDStudent);
        void Update(Student stu);
        //Student GetByStatus(bool status);
     
        void Save();
        void Insert(CreatStudents model);
        //void Edit(EditStudents modelE);
        string GenerateMSSV(int KhoaId, int YearId);
        
        GetAllStudents GetID(int Id);
        void Update(EditStudents modelE);
        void DeleteMSSV(string mssv);
        int CheckClass(int idClass);

        //IEnumerable<Student> GetByStatus();
        //void Delete(int studentId);
    }
}
