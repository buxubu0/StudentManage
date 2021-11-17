using StudentManage.Models;
using StudentManage.Sevices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.Sevices.Repo
{
    public class YearRepo : IYear
    {
        private StudentEntities _dby = new StudentEntities();

        public bool CheckYearCode(string code)
        {
            if (_dby.Years.Any(x => x.Year_Code == code))
            {
                return true;
            }
                return false;
        }

        public void Delete(Year year)
        {
            _dby.Years.Remove(year);
        }

        public void DeleteYearCode(string yearCode)
        {
            var listYear = _dby.Years.Where(x => x.Year_Code == yearCode).FirstOrDefault();
            _dby.Years.Remove(listYear);
            Save();
        }

        public IEnumerable<Year> GetAll()
        {
            var listYear = _dby.Years.AsEnumerable().ToList();
            return listYear;
        }

        public Year GetByID(int Id)
        {
            Year year = _dby.Years.Find(Id);
            return year;
        }

       

        public IEnumerable<Year> GetID(int Id)
        {
            var listId = (from stu in _dby.Students
                          join sk in _dby.StudentOfKhoas on stu.ID equals sk.StudentID
                          join k in _dby.Khoas on sk.KhoaID equals k.ID
                          join sy in _dby.StudentJoinYears on stu.ID equals sy.StudentID
                          join y in _dby.Years on sy.YearID equals y.ID
                          select new Year
                          {
                              ID = y.ID,
                              Year_Code = y.Year_Code,
                              Year_Name = y.Year_Name
                          }).AsEnumerable().Where(x => x.ID == Id).ToList();
            return listId;
        }

        public Year GetYear_Code(string yearcode)
        {
            IEnumerable<Year> years = GetAll();
            Year y = years.Where(x => x.Year_Code == yearcode).FirstOrDefault();
            return y;
        }

        public void Insert(Year year)
        {
            _dby.Years.Add(year);
        }

        public void Save()
        {
            _dby.SaveChanges();
        }

        public void Update(Year year)
        {
            _dby.Entry(year).State = System.Data.Entity.EntityState.Modified;
        }
    }
}