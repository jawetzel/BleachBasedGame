using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Database;
using CoreRepo.Database.Tables.Account;
using CoreRepo.IDataAccess.IAccountAccess;

namespace CoreRepo.DataAccess.AccountAccess
{
    public class SessionAccess : BaseDataAccess<Session>, ISessionAccess
    {
        private readonly CoreContext _context;

        public SessionAccess(CoreContext context)
        {
            _context = context;
        }

        public Session GetByToken(string token)
        {
            return _context.Sessions.FirstOrDefault(sess => sess.Token.Equals(token));
        }


        public List<Session> GetListByUserId(int id)
        {
            return _context.Sessions.Where(sess => sess.UserId == id).ToList();
        }
    }
}
