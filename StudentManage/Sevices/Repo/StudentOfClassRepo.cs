using StudentManage.Sevices.Interface;
using System;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.Sevices.Repo
{
    public class StudentOfClassRepo : IStudentOfClass
    {
        private readonly StudentEntities _db = new StudentEntities();
        public void Delete(int Studentid)
        {
            var liststuOfClass = _db.StudentOfClassses.Where(x => x.StudentID == Studentid).FirstOrDefault();
            _db.StudentOfClassses.Remove(liststuOfClass);
            save();
        }

        public void DeleteMSSV(int ID)
        {
            var listMSSV = _db.StudentOfClassses.Where(x => x.StudentID == ID).FirstOrDefault();
            _db.StudentOfClassses.Remove(listMSSV);
            save();

        }

        public StudentOfClasss GetByStudentID(int studentId)
        {
            var listIdStudent = _db.StudentOfClassses.Where(x => x.StudentID == studentId).FirstOrDefault();
            return listIdStudent;
        }

        public void Insert(int Studentid, int Classid)
        {
            StudentOfClasss insertStu = new StudentOfClasss()
            {
                StudentID = Studentid,
                ClassID = Classid
            };
            _db.StudentOfClassses.Add(insertStu);
            save();
        }

        public void save()
        {
            _db.SaveChanges();
        }

        public void Update(int Studentid, int Classid)
        {
            var stuOfClass = GetByStudentID(Studentid);
            if(stuOfClass.ClassID != Classid)
            {
                stuOfClass.ClassID = Classid;
                _db.Entry(stuOfClass).State = System.Data.Entity.EntityState.Modified;
                save();
            }
        }
    }
}