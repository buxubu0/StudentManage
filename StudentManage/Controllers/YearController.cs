using StudentManage.Models;
using StudentManage.Sevices.Interface;
using StudentManage.Sevices.Repo;
using StudentManage.ViewModels.YearViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManage.Controllers
{
    public class YearController : Controller
    {
        // GET: Year
        private IYear yearService = new YearRepo();
        public ActionResult Index()
        {
            var listKhoa = yearService.GetAll();
            return View(listKhoa);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateYear modelyear)
        {
            if (yearService.CheckYearCode(modelyear.Year_Code))
            {
                ModelState.AddModelError("Year_Code", "Mã này đã tồn tại");
                return View(modelyear);
            };
            if (ModelState.IsValid)
            {
                Year year = new Year()
                {
                    Year_Code = modelyear.Year_Code,
                    Year_Name = modelyear.Year_Name
                };
                yearService.Insert(year);
                yearService.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Year year = yearService.GetByID(Id);
            if (year is null)
            {
                return HttpNotFound();
            }
            EditYear eyear = new EditYear()
            {
                Year_Code = year.Year_Code,
                Year_Name = year.Year_Name
            };
            return View(eyear);
        }

        [HttpPost]
        public ActionResult Edit(EditYear modelYear)
        {
            if (ModelState.IsValid)
            {
                Year year = new Year()
                {
                    ID = modelYear.ID,
                    Year_Code = modelYear.Year_Code,
                    Year_Name = modelYear.Year_Name
                };
                yearService.Update(year);
                yearService.Save();
                return RedirectToAction("Index");
            }
            return View(modelYear);
        }

        [HttpGet]
        public ActionResult Detail(int Id)
        {
            Year year = yearService.GetByID(Id);
            if (year is null)
            {
                return HttpNotFound();
            }
            Details detailsYear = new Details()
            {
                ID = year.ID,
                Year_Code = year.Year_Code,
                Year_Name = year.Year_Name
            };
            return View(detailsYear);
        }

        //[HttpPost]
        //public ActionResult Delete(int Id)
        //{
        //    Year year = yearService.GetByID(Id);
        //    if(year is null)
        //    {
        //        return HttpNotFound();
        //    }
        //    yearService.Delete(year);
        //    yearService.Save();
        //    return RedirectToAction("Index");
        //}

        ///ajax
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            string messenge = "";
            bool success = default;
            Year year = yearService.GetByID(Id);
            if (year is null)
            {
                messenge = "Id Bạn Tìm Không Tồn Tại";
                success = false;
            }
            if (year.StudentJoinYears.Count > 0)
            {
                messenge = "Không Thể Xóa Sinh Viên Đã Tồn Tại";
                success = false;
            }
            else
            {
                messenge = "Xóa Thành Công !";
                success = true;
                yearService.Delete(year);
                yearService.Save();
            }

            return Json(new { messenge = messenge, success = success }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult DeleteYearCode(string yearCode)
        {
            string messenge = "";
            bool success = default;
           
                messenge = "Xóa Thành Công !";
                success = true;

                yearService.DeleteYearCode(yearCode);
           
           

            return Json(new { messenge = messenge, success = success }, JsonRequestBehavior.AllowGet);
        }
    }
}