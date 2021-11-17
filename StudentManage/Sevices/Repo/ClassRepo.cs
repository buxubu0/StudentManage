using StudentManage.Sevices.Interface;
using System;
using System.Collections.Generic;
using StudentManage.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManage.ViewModels.ClassViewModels;
using StudentManage.ViewModels.StudentViewModels;

namespace StudentManage.Sevices.Repo
{
    public class ClassRepo : IClass
    {
        private readonly StudentEntities _db = new StudentEntities();
        private IKhoa khoaService = new KhoaRepo();
        private ITeacher teacherService = new TeacherRepo();

     

        public bool CheckMa(string ma)
        {
            if(_db.Classes.Any(x=>x.MaClass == ma))
            {
                return true;
            }
            return false;
        }

        public int CheckTeacher(int checkTeacherId)
        {
            int listTeacher = _db.Classes.Where(x => x.TeacherID == checkTeacherId).Count();
            return listTeacher;
        }

        public void Delete(int  IdClass)
        {
            //teacherService.Delete(IdClass);
            var listClass = _db.Classes.Find(IdClass);
            _db.Classes.Remove(listClass);
            Save();
        }

       

        public IEnumerable<Class> GetAllClass()
        {
            //var listStuOfClass = _db.StudentOfClassses.Count();
            //var listClass = _db.Classes.Where(x=>x.SoLuongHS >= listStuOfClass).ToList();
            //return listClass;
            List<Class> listClass = new List<Class>();// lưu trữ danh sách các lớp thõa mãn đk
            List<Class> allClass = _db.Classes.ToList();// lấy lên tất cả danh sách lớp
            foreach(var cl in allClass ){
                //var countStudent = _db.StudentOfClassses.Where(x => x.ClassID == cl.ID).Count();
                if(cl.SoLuongHS > cl.StudentOfClassses.Count())// 20 vs 18 18 > 20
                {
                    listClass.Add(cl);
                }
            }
            return listClass;
        }

        public Class GetByID(int id)
        {
            var listID = _db.Classes.Find(id);
            return listID;
        }

        public void Insert(Class lop)
        {
            _db.Classes.Add(lop);
        }


        public void Save()
        {
            _db.SaveChanges();
        }


        public void UpdateClass(EditClass model)
        {
            Class clas = GetByID(model.ID);
            clas.MaClass = model.MaClass;
            clas.NameClass = model.NameClass;
            clas.TeacherID = model.TeacherID;
            _db.Entry(clas).State = System.Data.Entity.EntityState.Modified;
            Save();
            
        }
        
    }
}