using PAP.DataBase.Auth;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PAP.DataBase
{
    public class EventAccount
    {
        [Key]
        public int EventAccountId { get; set; }

        public Guid AccountId { get; set; }

        public int EventId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual User Account { get; set; }

        [ForeignKey(nameof(EventId))]
        public virtual Event Event { get; set; }
    }
}
