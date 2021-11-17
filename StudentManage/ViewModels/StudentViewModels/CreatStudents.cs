using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StudentManage.Models;
using System.Linq;
using System.Web;


namespace StudentManage.ViewModels.StudentViewModels
{
    public class CreatStudents
    {
        public string MSSV { get; set; }
        [Required(ErrorMessage ="Vui Lòng Nhập")]
        [MaxLength(20,ErrorMessage ="Không Được Quá 20 Ký Tự")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vui Lòng Nhập")]
        [MaxLength(10, ErrorMessage = "Không Được Quá 10 Ký Tự")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Vui Lòng Nhập")]
        [MaxLength(200, ErrorMessage = "Không Được Quá 200 Ký Tự")]
        public string Address { get; set; }
        
        public IEnumerable<Year>  Years { get; set; }
        
        public IEnumerable<Khoa> Khoas { get; set; }
        public bool Status { get; set; }
        public int Counts { get; set; }
        
        public string YearName { get; set; }
        public string KhoaName { get; set; }
  
        public int YearID { get; set; }
        public int KhoaID { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public int ClassID { get; set; }


    }

    public class EditStudents : CreatStudents
    {
        public int ID { get; set; }
      
    }
    
    public class Details : CreatStudents
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string NameTeacher { get; set; }
       
    }
}