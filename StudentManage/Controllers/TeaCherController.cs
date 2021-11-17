using StudentManage.Sevices.Interface;
using StudentManage.Sevices.Repo;
using System;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManage.ViewModels.TeacherViewModels;

namespace StudentManage.Controllers
{
    public class TeaCherController : Controller
    {
        private ITeacher teacherService = new TeacherRepo();
        // GET: TeaCher
        public ActionResult Index()
        {
            var listTeacher = teacherService.GetAllTeacher();
            return View(listTeacher);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateTeachers model)
        {
            if (ModelState.IsValid)
            {
                Teacher teacher = new Teacher()
                {
                    NameTeacher = model.NameTeacher,
                    Old = model.Old,
                    Address = model.Address,
                    Email = model.Email
                };
                teacherService.Insert(teacher);
                teacherService.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Teacher teachers = teacherService.GetIDTeacher(Id);
            if (teachers is null)
            {
                return HttpNotFound();
            }
            EditTeacher editTea = new EditTeacher()
            {
                NameTeacher = teachers.NameTeacher,
                Old = (int)teachers.Old,
                Address = teachers.Address,
                Email = teachers.Email
            };
            return View(editTea);
        }
        [HttpPost]
        public ActionResult Edit(EditTeacher model)
        {
            if (ModelState.IsValid)
            {
                Teacher teas = new Teacher()
                {
                    ID = model.ID,
                    NameTeacher = model.NameTeacher,
                    Old = model.Old,
                    Address = model.Address,
                    Email = model.Email
                };
                teacherService.Update(teas);
                teacherService.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int Id)
        {
            Teacher listTeasId = teacherService.GetIDTeacher(Id);
            if (listTeasId is null)
            {
                return HttpNotFound();
            }
            Detail details = new Detail()
            {
                NameTeacher = listTeasId.NameTeacher,
                Old = (int)listTeasId.Old,
                Address = listTeasId.Address,
                Email = listTeasId.Email
            };
            return View(details);

        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            string messenger = "";
            bool success = default;

            Teacher teachers = teacherService.GetIDTeacher(Id);
            if (teachers is null)
            {
                messenger = "Không Tồn Tại Giáo Viên";
                success = false;
            }
            //if (teachers.)
            //{

            //}
            else
            {
                messenger = "Xóa Thành Công";
                success = true;
                teacherService.Delete(teachers);
                teacherService.Save();
            }
            return Json(new { mess = messenger, succ = success }, JsonRequestBehavior.AllowGet);
        }
    }
}