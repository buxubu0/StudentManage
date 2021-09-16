using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManage.ViewModels.YearViewModel
{
    public class CreateYear
    {
        [Required(ErrorMessage ="Vui long nhap ma nam")]
        [MaxLength(5,ErrorMessage ="Ma nam khong qua 5 ki tu")]
        public string Year_Code { get; set; }
        [Required(ErrorMessage = "Vui long nhap ten nam")]
        [MaxLength(50, ErrorMessage = "Ten nam khong qua 50 ki tu")]
        public string Year_Name { get; set; }
    }

    public class EditYear : CreateYear
    {
        public int ID { get; set; }
    }

    public class Details : CreateYear
    {
        public int ID { get; set; }
    }
}