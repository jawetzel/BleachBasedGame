using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.Database.Tables.PrivateMessage
{
    public class MessageGroup : BaseTable
    {

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<GroupMessage> GroupMessages { get; set; }
        public ICollection<MessageGroupUser> MessageGroupUsers { get; set; }
    }
}
