using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.ViewModels
{
    public class GetAllStudents
    {
        public int ID { get; set; }
        public string MSSV { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Khoa { get; set; }
        public string Nam { get; set; }
        public string Class { get; set; }
        public string Teachers { get; set; }
        public bool Status { get; set; }
        public bool Count { get; set; }
     
    }
}