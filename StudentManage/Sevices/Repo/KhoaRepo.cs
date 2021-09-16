using StudentManage.Models;
using StudentManage.Sevices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.Sevices.Repo
{
    public class KhoaRepo : IKhoa
    {
        private readonly StudentEntities _dbk = new StudentEntities();
        public void Delete(Khoa khoa)
        {
            _dbk.Khoas.Remove(khoa);
        }

        public IEnumerable<Khoa> GetAll()
        {
            var listKhoa = _dbk.Khoas.AsEnumerable().ToList();
            return listKhoa;
        }

        public Khoa GetByID(int Id)
        {
            var listKhoa = _dbk.Khoas.Find(Id);
            return listKhoa;
        }

        public Khoa GetByKhoa_Code(string khoacode)
        {
            IEnumerable<Khoa> khoas = GetAll();
            Khoa k = khoas.Where(x => x.Khoa_Code == khoacode).FirstOrDefault();
            return k;
        }

        public void Insert(Khoa khoa)
        {
            _dbk.Khoas.Add(khoa);
        }


        public void Save()
        {
            _dbk.SaveChanges();
        }

        public void Update(Khoa khoa)
        {
            _dbk.Entry(khoa).State = System.Data.Entity.EntityState.Modified;
        }
    }
}