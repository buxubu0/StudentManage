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
            if(year is null)
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
            if(year is null)
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
            Year year = yearService.GetByID(Id);
            if (year is null)
            {
                return HttpNotFound();
            }
            yearService.Delete(year);
            yearService.Save();
            return RedirectToAction("Index");
        }
    }
}