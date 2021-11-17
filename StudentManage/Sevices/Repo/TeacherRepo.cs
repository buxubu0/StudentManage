using StudentManage.Models;
using StudentManage.Sevices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.Sevices.Repo
{
    public class TeacherRepo : ITeacher
    {
        private readonly StudentEntities _db = new StudentEntities();
        //public void Delete(int IdClass)
        //{
        //    var listTeacher = _db.Teachers.Where(x => x.ID == IdClass).FirstOrDefault();
        //    _db.Teachers.Remove(listTeacher);
        //    Save();
        //}

        //public void Delete(int IdTeacher)
        //{
        //    var listTeacher = _db.Teachers.Where(x => x.ID == IdTeacher).FirstOrDefault();
        //    _db.Teachers.Remove(listTeacher);
        //    Save();
        //}

        public void Delete(Teacher IdTeacher)
        {
            _db.Teachers.Remove(IdTeacher);
        }

        public IEnumerable<Teacher> GetAllTeacher()
        {
            var listTeacher = _db.Teachers.AsEnumerable().ToList();
            return (listTeacher);
        }

        public Teacher GetIDTeacher(int id)
        {
            var listTeac = _db.Teachers.Find(id);
            return listTeac;
        }

        public void Insert(Teacher gv)
        {
            _db.Teachers.Add(gv);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Teacher gv)
        {

            _db.Entry(gv).State = System.Data.Entity.EntityState.Modified;
        }
    }
}