using StudentManage.Models;
using StudentManage.Sevices.Interface;
using StudentManage.Sevices.Repo;
using StudentManage.ViewModels.ClassViewModels;
using StudentManage.ViewModels.StudentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManage.Controllers
{
    public class ClassController : Controller
    {
        // GET: AllClass
        private IClass classService = new ClassRepo();
        private IStudentOfClass studentOfClass = new StudentOfClassRepo();
        private ITeacher teacherService = new TeacherRepo();
        public ActionResult Index()
        {
            var listClass = classService.GetAllClass();
            return View(listClass);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateClass creates = new CreateClass()
            {
                Teachers = teacherService.GetAllTeacher()
            };
            return View(creates);
        }

        [HttpPost]
        public ActionResult Create(CreateClass model)
        {

            if (ModelState.IsValid)
            {

                if (classService.CheckMa(model.MaClass))
                {
                    ModelState.AddModelError("MaClass", "Mã Này Đã Tồn Tại");
                    model.Teachers = teacherService.GetAllTeacher();
                    return View(model);
                }

                if (classService.CheckTeacher(model.TeacherID) >= 5)
                {
                    ModelState.AddModelError("TeacherID", "Giáo viên này đã nhận đủ lớp");
                    model.Teachers = teacherService.GetAllTeacher();
                    return View(model);
                }
                Class classes = new Class()
                {
                    MaClass = model.MaClass,
                    NameClass = model.NameClass,
                    TeacherID = model.TeacherID
                };
                classService.Insert(classes);
                classService.Save();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
           
            Class clas = classService.GetByID(id);
            if(clas is null)
            {
                return HttpNotFound();
            }
            EditClass editClas = new EditClass()
            {
                ID = clas.ID,
                MaClass = clas.MaClass,
                NameClass = clas.NameClass,
                Teachers = teacherService.GetAllTeacher(),
                TeacherID = clas.TeacherID

            };
            return View(editClas);
        }

        [HttpPost]
        public ActionResult Edit(EditClass model)
        {
            
            classService.UpdateClass(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int Id)
        {
            Class detailList = classService.GetByID(Id);
            if(detailList is null)
            {
                return HttpNotFound();
            }
            Detaill details = new Detaill()
            {
                MaClass = detailList.MaClass,
                NameClass = detailList.NameClass,
                NameTeacher = detailList.Teacher.NameTeacher
            };
            return View(details);

        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            string messenger = "";
            bool succes = default;
            Class getIdClass = classService.GetByID(Id); 
            if(getIdClass is null)
            {
                messenger = "ID Không Tồn Tại";
                succes = false;
            }
            //if(getIdClass.TeacherID > 0)
            //{
            //    messenger = "Không Thể Xóa Sinh Viên Đang Tồn Tại";
            //    succes = false;
            //}
            else
            {
                classService.Delete(Id);
                messenger = "Xóa Thành Công";
                succes = true;
            }

            return Json(new { mess = messenger, suc = succes }, JsonRequestBehavior.AllowGet);
        }
    }
}