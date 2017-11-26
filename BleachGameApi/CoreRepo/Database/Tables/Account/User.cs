using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreRepo.Database.Tables.Global;
using CoreRepo.Database.Tables.PrivateMessage;

namespace CoreRepo.Database.Tables.Account
{
    public class User : BaseTable
    {
        public User()
        {//begin constructor
            IsVerified = false;
            IsOnline = false;
        }//end constructor

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public bool IsVerified { get; set; }
        public string VerifyString { get; set; }

        public bool IsOnline { get; set; }
        public string ConnectionId { get; set; }

        public string UserName { get; set; }
        public decimal PositionX { get; set; }
        public decimal PositionY { get; set; }
        public decimal PositionZ { get; set; }
        public int FacingDirection { get; set; }

        public int MaxHealth { get; set; }
        public int Health { get; set; }

        public ICollection<UsersRole> UsersRoles { get; set; }
        public ICollection<Session> Sessions { get; set; }

        public ICollection<GroupMessage> GroupMessages { get; set; }
        public ICollection<MessageGroup> MessageGroups { get; set; }
        public ICollection<MessageGroupUser> MessageGroupUsers { get; set; }

        public ICollection<WorldMessage> WorldMessages { get; set; }

    }
}
