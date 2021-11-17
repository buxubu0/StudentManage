using StudentManage.Sevices.Interface;
using System;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.Sevices.Repo
{
    public class StudentOfKhoaRepo : IStudentOfKhoa
    {
        private readonly StudentEntities _dbstu = new StudentEntities();

      

        public StudentOfKhoa GetByID(int Id)
        {
            var listKhoa = _dbstu.StudentOfKhoas.Find(Id);
            return listKhoa;
        }

        public StudentOfKhoa GetByStudentID(int StudentId)
        {
            var studentId = _dbstu.StudentOfKhoas.Where(x => x.StudentID == StudentId).FirstOrDefault();
            return studentId;
        }

        //public StudentOfKhoaRepo(StudentEntities db)
        //{
        //    _dbstu = db;
        //}
        public void Insert(int StudentId, int KhoaId)
        {
            StudentOfKhoa obj = new StudentOfKhoa()
            {
                StudentID = StudentId,
                KhoaID = KhoaId
            };
            _dbstu.StudentOfKhoas.Add(obj);
            Save();
            
        }

        public void Save()
        {
            _dbstu.SaveChanges();
        }

        public void Update(int StudentID, int KhoaID)
        {
            var stuOfKhoa = GetByStudentID(StudentID);
            if (stuOfKhoa.KhoaID != KhoaID)
            {
                stuOfKhoa.KhoaID = KhoaID;
                _dbstu.Entry(stuOfKhoa).State = System.Data.Entity.EntityState.Modified;
                Save();
            }

        }

        public void Delete(int studentId)
        {
            var product = _dbstu.StudentOfKhoas.Where(x => x.StudentID == studentId).FirstOrDefault();
                _dbstu.StudentOfKhoas.Remove(product);
            Save();
            }

        public void DeleteMSSV(int IDmssv)
        {

            var mssv = _dbstu.StudentOfKhoas.Where(x => x.StudentID == IDmssv).FirstOrDefault();
            _dbstu.StudentOfKhoas.Remove(mssv);
            Save();
            
        }
    }
    }
