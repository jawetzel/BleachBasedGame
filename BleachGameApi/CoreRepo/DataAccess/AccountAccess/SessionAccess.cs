using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Database;
using CoreRepo.Database.Tables.Account;
using CoreRepo.IDataAccess.IAccountAccess;

namespace CoreRepo.DataAccess.AccountAccess
{
    public class SessionAccess : ISessionAccess
    {
        private readonly CoreContext _context;

        public SessionAccess(CoreContext context)
        {
            _context = context;
        }

        public Session Create(Session model)
        {
            try
            {
                _context.Sessions.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Session Update(Session model)
        {
            try
            {
                _context.Sessions.Update(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Session model)
        {
            try
            {
                _context.Sessions.Remove(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Session GetById(int id)
        {
            return _context.Sessions.FirstOrDefault(sess => sess.Id == id);
        }

        public Session GetByToken(string token)
        {
            return _context.Sessions.FirstOrDefault(sess => sess.Token.Equals(token));
        }

        public List<Session> GetAll()
        {
            return _context.Sessions.Where(sess => sess != null).ToList();
        }

        public List<Session> GetListByUserId(int id)
        {
            return _context.Sessions.Where(sess => sess.UserId == id).ToList();
        }
    }
}
