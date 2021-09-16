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
        public void Delete(Year year)
        {
            _dby.Years.Remove(year);
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