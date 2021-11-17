using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using StudentManage.Models;
using System.Web;

namespace StudentManage.ViewModels.ClassViewModels
{
    public class CreateClass
    {
       
        public int ID { get; set; }
        [Required(ErrorMessage = "Vui long nhap")]
        [MaxLength(10, ErrorMessage ="Ma lop khong duoc qua 10 ki tu")]
        public string MaClass { get; set; }
        [Required(ErrorMessage = "Vui long nhap")]
        [MaxLength(50, ErrorMessage = "Ten lop khong duoc qua 50 ki tu")]
        public string NameClass { get; set; }
        public int TeacherID { get; set; }
        public bool Counts { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
 
    }
    public class EditClass : CreateClass
    {

    }
    public class Detaill : CreateClass
    {
        public string NameTeacher { get; set; }
    }
}