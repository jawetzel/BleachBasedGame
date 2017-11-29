using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using CoreRepo.Database;
using CoreRepo.Database.Tables;
using CoreRepo.IDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreRepo.DataAccess
{
    public class BaseDataAccess<T> : IBaseDataAccess<T> where T : BaseTable
    {
        private readonly CoreContext _context;
        private readonly DbSet<T> _entity;

        public BaseDataAccess(CoreContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        protected BaseDataAccess()
        {
        }

        public List<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(int id)
        {
            return _entity.FirstOrDefault(item => item.Id == id);
        }

        public T Create(T model)
        {
            try
            {
                _entity.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public T Update(T model)
        {
            try
            {
                _entity.Update(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(T model)
        {
            try
            {
                _entity.Remove(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
