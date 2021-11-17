using StudentManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.Sevices.Interface
{
    public interface IKhoa
    {
        IEnumerable<Khoa> GetAll();

        Khoa GetByKhoa_Code(string khoacode);
        Khoa GetByID(int Id);
        void Insert(Khoa khoa);
        void Delete(Khoa khoa);
        void Update(Khoa khoa);
        void Save();
        bool CheckCode(string code);
        void DeleteKhoaCode(string khoaCode);
    }
}