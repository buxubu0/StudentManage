using StudentManage.Sevices.Interface;
using StudentManage.Sevices.Repo;
using StudentManage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManage.Controllers
{
    public class StudentController : Controller
    {
        // GET: AllStudent
        private readonly IStudent _studentService = new StudentRepo();

        //public object GetAllStudent { get; private set; }

        public ActionResult Index()
        {
            var list = _studentService.GetAll();
            return View(list);
        }
        
    }
}