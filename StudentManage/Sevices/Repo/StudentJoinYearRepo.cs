using StudentManage.Sevices.Interface;
using System;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.Sevices.Repo
{
    public class StudentJoinYearRepo : IStudentJoinYear
    {
        private readonly StudentEntities _db = new StudentEntities();

        public void Delete(StudentJoinYear model)
        {
            _db.StudentJoinYears.Remove(model);
        }



        public StudentJoinYear GetByID(int Id)
        {
            var listId = _db.StudentJoinYears.Find(Id);
            return listId;
        }

        public StudentJoinYear GetByStudentID(int studentId)
        {
            var student = _db.StudentJoinYears.Where(x => x.StudentID == studentId).FirstOrDefault();
            return student;
        }



        //public StudentJoinYearRepo(StudentEntities db)
        //{
        //    _db = db;
        //}
        public void Insert(int StudentId, int YearId)
        {
            StudentJoinYear obj = new StudentJoinYear()
            {
                StudentID = StudentId,
                YearID = YearId
            };
            _db.StudentJoinYears.Add(obj);
            Save();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(int StudentId, int YearId)
        {
            var stuJionYear = GetByStudentID(StudentId);
            if (stuJionYear.YearID != YearId)
            {
                stuJionYear.YearID = YearId;
                _db.Entry(stuJionYear).State = System.Data.Entity.EntityState.Modified;
                Save();
            }

        }

        public void Delete(int studentID)
        {
            var product = _db.StudentJoinYears.Where(x => x.StudentID == studentID).FirstOrDefault(); //var stuYear = GetByID(studentID);
            _db.StudentJoinYears.Remove(product);
            Save();
        }

        public void DeleteMSSV(int IDMSSV)
        {
            var mssv = _db.StudentJoinYears.Where(x => x.StudentID == IDMSSV).FirstOrDefault();
            _db.StudentJoinYears.Remove(mssv);
            Save();
        }
    }
}
