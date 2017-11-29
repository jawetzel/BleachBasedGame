using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Database.Tables;

namespace CoreRepo.IDataAccess
{
    public interface IBaseDataAccess<T> where T : BaseTable
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T model);
        T Update(T model);
        bool Delete(T model);
    }
}
