using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManage.ViewModels.KhoaViewModel
{
    public class CreateKhoa
    {
        [Required(ErrorMessage = "Vui Long Nhap Ma Khoa")]
        [MaxLength(5, ErrorMessage = "Ma khoa khong duoc qua 5 ki tu")]
        public string Khoa_Code { get; set; }
        [Required(ErrorMessage = "Vui Long Nhap Ten Khoa")]
        [MaxLength(50, ErrorMessage = "Ten khoa khong duoc dai hon 50 ki tu")]
        public string Khoa_Name { get; set; }
    }

    public class EditKhoa : CreateKhoa
    {
        [Required]
        public int ID { get; set; }
    }

    public class Details : CreateKhoa
        {
        public int ID { get; set; }
        }
}
