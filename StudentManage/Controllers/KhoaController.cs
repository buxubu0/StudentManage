using StudentManage.Models;
using StudentManage.Sevices.Interface;
using StudentManage.Sevices.Repo;
using StudentManage.ViewModels.KhoaViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManage.Controllers
{
    public class KhoaController : Controller
    {
        private IKhoa khoaService = new KhoaRepo();
        //private object listKhoa;

        //private object listKhoa;

        //private object khoa;

        // GET: Khoa
        public ActionResult Index()
        {
            var listKhoa = khoaService.GetAll();
            return View(listKhoa);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateKhoa model)
        {
            if (khoaService.CheckCode(model.Khoa_Code))
            {
                ModelState.AddModelError("Khoa_Code", "Mã này đã tồn tại");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                Khoa khoa = new Khoa()
                {
                    Khoa_Code = model.Khoa_Code,
                    Khoa_Name = model.Khoa_Name
                };
                khoaService.Insert(khoa);
                khoaService.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Khoa khoa = khoaService.GetByID(Id);
            if (khoa is null)
            {
                return HttpNotFound();
            }
            EditKhoa objKhoa = new EditKhoa()
            {
                ID = khoa.ID,
                Khoa_Code = khoa.Khoa_Code,
                Khoa_Name = khoa.Khoa_Name
            };
            return View(objKhoa);
        }

        [HttpPost]
        public ActionResult Edit(EditKhoa modelKhoa)
        {
            if (ModelState.IsValid)
            {
                Khoa eKhoa = new Khoa()
                {
                    ID = modelKhoa.ID,
                    Khoa_Code = modelKhoa.Khoa_Code,
                    Khoa_Name = modelKhoa.Khoa_Name
                };
                khoaService.Update(eKhoa);
                khoaService.Save();
                return RedirectToAction("Index");
            }
            return View(modelKhoa);
        }

        [HttpGet]
        public ActionResult Detail(int Id)
        {
            Khoa khoa = khoaService.GetByID(Id);
            if (khoa is null)
            {
                return HttpNotFound();
            }
            Details deKhoa = new Details()
            {
                ID = khoa.ID,
                Khoa_Code = khoa.Khoa_Code,
                Khoa_Name = khoa.Khoa_Name
            };
            return View(deKhoa);
        }

        //[HttpPost]
        //public ActionResult Delete(int Id)
        //{
        //    Khoa khoa = khoaService.GetByID(Id);
        //    if(khoa is null)
        //    {
        //        return HttpNotFound();
        //    };
        //    khoaService.Delete(khoa);
        //    khoaService.Save();
        //    return RedirectToAction("Index");
        //}


        //ajax
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            string messenger = "";
            bool success = false;
            Khoa khoa = khoaService.GetByID(Id);
            if (khoa is null)
            {
                messenger = "Id không tồn tại";
                success = false;
            }
            if (khoa.StudentOfKhoas.Count > 0)
            {
                messenger = "Sinh Viên Này Đã Tồn Tại";
                success = false;
            }
            else
            {
                khoaService.Delete(khoa);
                khoaService.Save();
                messenger = "Xóa Thành Công";
                success = true;
            }
            return Json(new { messenger = messenger, success = success }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteKhoaCode(string khoaCode)
        {
            string messenger = "";
            bool success = false;
            
         
            
                khoaService.DeleteKhoaCode(khoaCode);

                messenger = "Xóa Thành Công";
                success = true;
            
            return Json(new { messenger = messenger, success = success }, JsonRequestBehavior.AllowGet);
        }

    }

}
