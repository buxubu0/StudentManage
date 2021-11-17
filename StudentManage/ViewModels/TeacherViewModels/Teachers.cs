using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManage.ViewModels.TeacherViewModels
{
    public class CreateTeachers
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Vui long nhap Ten")]
        public string NameTeacher { get; set; }
        [Required(ErrorMessage = "Vui long nhap Tuoi")]
        public int Old { get; set; }
        [Required(ErrorMessage = "Vui long nhap Dia Chi")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui long nhap Mail")]
        public string Email { get; set; }
    }
    public class EditTeacher : CreateTeachers
    {

    }
    public class Detail : CreateTeachers
    {

    }
}