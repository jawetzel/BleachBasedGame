using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreRepo.Database.Tables
{
    public class BaseTable
    {
        public BaseTable()
        {
            CreatedDate = DateTime.UtcNow;
            LastEditedDate = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastEditedDate { get; set; }
    }
}
