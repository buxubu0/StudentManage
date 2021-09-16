﻿using StudentManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.Sevices.Interface
{
    public interface IYear
    {
        IEnumerable<Year> GetAll();

        Year GetYear_Code(string yearcode);
        Year GetByID(int Id);
        void Insert(Year year);
        void Delete(Year year);
        void Update(Year year);
        void Save();

    }
}