using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentManage.Models;
using StudentManage.Sevices.Interface;
using StudentManage.ViewModels;
using StudentManage.ViewModels.StudentViewModels;

namespace StudentManage.Sevices.Repo
{
    public class StudentRepo : IStudent
    {
        private StudentEntities _db = new StudentEntities();// ket noi csdl
        private IKhoa _khoaService = new KhoaRepo();
        private IYear _yearService = new YearRepo();
        private IStudentJoinYear studentJoinYear = new StudentJoinYearRepo();
        private IStudentOfKhoa studentOfKhoa = new StudentOfKhoaRepo();
        private IClass classe = new ClassRepo();
        private IStudentOfClass studentofclass = new StudentOfClassRepo();





        public IEnumerable<GetAllStudents> GetAll()
        {
            var listStudent = (from stu in _db.Students
                               join sk in _db.StudentOfKhoas on stu.ID equals sk.StudentID
                               join k in _db.Khoas on sk.KhoaID equals k.ID
                               join stuy in _db.StudentJoinYears on stu.ID equals stuy.StudentID
                               join y in _db.Years on stuy.YearID equals y.ID
                               join sc in _db.StudentOfClassses on stu.ID equals sc.StudentID
                               join cl in _db.Classes on sc.ClassID equals cl.ID
                               join t in _db.Teachers on cl.TeacherID equals t.ID
                               select new GetAllStudents
                               {
                                   ID = stu.ID,
                                   MSSV = stu.MSSV,
                                   FirstName = stu.FirstName,
                                   LastName = stu.LastName,
                                   Status = (bool)stu.Status,
                                   Count = (bool)cl.Counts,
                                   Khoa = k.Khoa_Name,
                                   Nam = y.Year_Name,
                                   Class = cl.NameClass,
                                   Teachers = t.NameTeacher
                               }
                               ).AsEnumerable().ToList();
            return listStudent;
        }
        GetAllStudents IStudent.GetID(int Id)
        {
            var listId = (from stu in _db.Students
                          join sk in _db.StudentOfKhoas on stu.ID equals sk.StudentID
                          join k in _db.Khoas on sk.KhoaID equals k.ID
                          join sy in _db.StudentJoinYears on stu.ID equals sy.StudentID
                          join y in _db.Years on sy.YearID equals y.ID
                          join stc in _db.StudentOfClassses on stu.ID equals stc.StudentID
                          join cl in _db.Classes on stc.ClassID equals cl.ID
                          join tc in _db.Teachers on cl.TeacherID equals tc.ID
                          select new GetAllStudents
                          {
                              ID = stu.ID,
                              MSSV = stu.MSSV,
                              FirstName = stu.FirstName,
                              LastName = stu.LastName,
                              Khoa = k.Khoa_Name,
                              Nam = y.Year_Name,
                              Class = cl.NameClass,
                              Teachers = tc.NameTeacher
                          }).AsEnumerable().Where(x => x.ID == Id).FirstOrDefault();
            return listId;
        }


        public Student GetByID(int Id)
        {
            var listStudent = _db.Students.Find(Id);
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

        public string GenerateMSSV(int KhoaId, int YearId)
        {
            string MSSV = "";
            // MSSV = "Khoa_Code + Year_Code = Y2021 loại bỏ = substring + 5 STT của sinh viên "
            string khoa_code = _khoaService.GetByID(KhoaId).Khoa_Code.Substring(0, 1);
            string year_code = _yearService.GetByID(YearId).Year_Code.Substring(1, 4);
            string countSTT = (_db.Students.Where(x => x.MSSV.Substring(0, 5) == khoa_code.ToUpper() + year_code).ToList().Count() + 1).ToString();
            switch (countSTT.Length)
            {
                case 1:
                    return MSSV += khoa_code.ToUpper() + year_code + "0000" + countSTT;
                case 2:
                    return MSSV += khoa_code.ToUpper() + year_code + "000" + countSTT;
                case 3:
                    return MSSV += khoa_code.ToUpper() + year_code + "00" + countSTT;
                case 4:
                    return MSSV += khoa_code.ToUpper() + year_code + "0" + countSTT;
                default:
                    return MSSV += khoa_code.ToUpper() + year_code + countSTT;
            }


        }

        public void Insert(CreatStudents model)
        {
            Student students = new Student()
            {
                MSSV = model.MSSV,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Status = model.Status
            };
            _db.Students.Add(students);
            Save();
            studentJoinYear.Insert(students.ID, model.YearID);
            studentOfKhoa.Insert(students.ID, model.KhoaID);
            studentofclass.Insert(students.ID, model.ClassID);
        }


        public void Update(EditStudents modelE)
        {
            Student student = GetByID(modelE.ID);
            student.LastName = modelE.LastName;
            student.FirstName = modelE.FirstName;
            student.Address = modelE.Address;
            student.Status = modelE.Status;
            Update(student);
            Save();
            studentJoinYear.Update(student.ID, modelE.YearID);
            studentOfKhoa.Update(student.ID, modelE.KhoaID);
            studentofclass.Update(student.ID, modelE.ClassID);
        }


        public void Delete(int  IDStudent)
        {
            studentJoinYear.Delete(IDStudent);
            studentOfKhoa.Delete(IDStudent);
            studentofclass.Delete(IDStudent);

            var student = _db.Students.Find(IDStudent);
            _db.Students.Remove(student);
            Save();
          
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

        public void DeleteMSSV(string mssv)
        {
            var mssvS = _db.Students.Where(x => x.MSSV == mssv).FirstOrDefault();
            studentOfKhoa.DeleteMSSV(mssvS.ID);
            studentJoinYear.DeleteMSSV(mssvS.ID);
            studentofclass.DeleteMSSV(mssvS.ID);

            _db.Students.Remove(mssvS);
            Save();
        }

        public int CheckClass(int idClass)
        {
            var listId = _db.StudentOfClassses.Where(x => x.ClassID == idClass).Count();
            return listId;
        }

      
    }
}