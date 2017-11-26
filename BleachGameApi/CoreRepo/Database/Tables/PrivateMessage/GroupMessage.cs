using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.Database.Tables.PrivateMessage
{
    public class GroupMessage : BaseTable
    {
        public string Message { get; set; }

        [ForeignKey("MessageGroup")]
        public int MessageGroupId { get; set; }
        public MessageGroup MessageGroup { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
