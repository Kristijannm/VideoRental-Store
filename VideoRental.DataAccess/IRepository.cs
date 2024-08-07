﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void Update (T entity);
        void DeleteById (int id);

    }
}
