using StudentManage.Sevices.Interface;
using StudentManage.Sevices.Repo;
using StudentManage.ViewModels.StudentViewModels;
using StudentManage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
using System.Web.Mvc;
using StudentManage.Models;

namespace StudentManage.Controllers
{
    public class StudentController : Controller
    {
        // GET: AllStudent
        private readonly IStudent _studentService = new StudentRepo();
        private readonly IKhoa _khoaservice = new KhoaRepo();
        private readonly IYear _yearService = new YearRepo();
        private readonly IStudentJoinYear _studentJoinYear = new StudentJoinYearRepo();
        private readonly IStudentOfKhoa _studentOfKhoa = new StudentOfKhoaRepo();
        private readonly IClass _classService = new ClassRepo();
        private readonly IStudentOfClass _studentOfClass = new StudentOfClassRepo();



      
        public ActionResult Search(string search)
        {
            var students = _studentService.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(x => x.LastName.Contains(search));
            }
            return View(students);
        }
        //[HttpPost]
        //public ActionResult Search(string nameFind)
        //{
        //    ViewBag.SearchKey = FormCollection["nameToFind"];
        //    return View();
        //}
        public ActionResult Index()
        {
            var list = _studentService.GetAll();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreatStudents studentsModel = new CreatStudents()
            {
                Years = _yearService.GetAll(),
                Khoas = _khoaservice.GetAll(),
                Classes = _classService.GetAllClass()
                //Status = _studentService.GetByStatus()

            };
            return View(studentsModel);
        }

        [HttpPost]
        public ActionResult Create(CreatStudents model)
        {
            if (ModelState.IsValid)
            {
                //if (_studentService.CheckClass(model.ClassID) >= 5)
                //{
                //    ModelState.AddModelError("ClassID", "Lớp này đã nhận đủ học sinh");
                //    model.Classes = _classService.GetAllClass();
                //    return View(model);
                //}
                string mssv = _studentService.GenerateMSSV(model.KhoaID, model.YearID);
                model.MSSV = mssv;
                _studentService.Insert(model);
                _studentService.Save();
               
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Student studentsId = _studentService.GetByID(Id);

            if (studentsId is null)
            {
                return HttpNotFound();
            }
            EditStudents eStu = new EditStudents()
            {
                ID = studentsId.ID,
                MSSV = studentsId.MSSV,
                FirstName = studentsId.FirstName,
                LastName = studentsId.LastName,
                Address = studentsId.Address,
                YearID = _studentJoinYear.GetByStudentID(studentsId.ID).YearID,
                KhoaID = _studentOfKhoa.GetByStudentID(studentsId.ID).KhoaID,
                ClassID = _studentOfClass.GetByStudentID(studentsId.ID).ClassID,
                Years = _yearService.GetAll(),
                Khoas = _khoaservice.GetAll(),
                Classes = _classService.GetAllClass()

            };
            return View(eStu);
        }

        [HttpPost]
        public ActionResult Edit(EditStudents modelE)
        {
            _studentService.Update(modelE);

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Detail(int Id)
        {
            Student stu = _studentService.GetByID(Id);
            GetAllStudents y = _studentService.GetID(Id);


            if (stu is null)
            {
                return HttpNotFound();
            }
            Details detail = new Details()
            {
                MSSV = stu.MSSV,
                FirstName = stu.FirstName,
                LastName = stu.LastName,
                Address = stu.Address,
                KhoaName = y.Khoa,
                YearName = y.Nam,
                ClassName = y.Class,
                NameTeacher = y.Teachers,
                Status = (bool)stu.Status

            };
            return View(detail);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {

            string messenge = "";
            bool success = default;


            _studentService.Delete(Id);

            messenge = "Xóa Thành Công";
            success = true;

            return Json(new { messenge = messenge, success = success }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteMSSV(string mssv)
        {

            string messenge1 = "";
            bool success1 = default;

            _studentService.DeleteMSSV(mssv);

            messenge1 = "Xóa Thành Công";
            success1 = true;

            return Json(new { messenge1 = messenge1, success1 = success1 }, JsonRequestBehavior.AllowGet);
        }

    }
}