using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentManage.Models;
using StudentManage.Sevices.Interface;
using StudentManage.ViewModels;

namespace StudentManage.Sevices.Repo
{
    public class StudentRepo : IStudent
    {
        private StudentEntities _db = new StudentEntities();

        public void Delete(Student stu)
        {
            _db.Students.Remove(stu);
        }

     

        public IEnumerable<GetAllStudents> GetAll()
        {
            var listStudent = (from stu in _db.Students
                               join sk in _db.StudentOfKhoas on stu.ID equals sk.StudentID
                               join k in _db.Khoas on sk.KhoaID equals k.ID
                               join stuy in _db.StudentJoinYears on stu.ID equals stuy.StudentID
                               join y in _db.Years on stuy.YearID equals y.ID
                               select new GetAllStudents
                               {
                                   ID = stu.ID,
                                   MSSV = stu.MSSV,
                                   FirstName = stu.FirstName,
                                   LastName = stu.LastName,
                                   Khoa = k.Khoa_Name,
                                   Nam = y.Year_Name
                               }
                               ).AsEnumerable().ToList();
            return listStudent;
        }

        public GetAllStudents GetByMssv(string mssv)
        {
            IEnumerable<GetAllStudents> getallstudents = GetAll();
            GetAllStudents stu = getallstudents.Where(x => x.MSSV == mssv).FirstOrDefault();
            return stu;
        }

        public void Insert(Student stu)
        {
            _db.Students.Add(stu);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Student stu)
        {
            _db.Entry(stu).State = System.Data.Entity.EntityState.Modified;
        }

        Student IStudent.GetByMssv(string mssv)
        {
            throw new NotImplementedException();
        }
    }
}