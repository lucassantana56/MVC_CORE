using PAP.DataBase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PAP.DataBase
{
    public class PublishEvent
    {
        [Key]
        public int PublishEventId { get; set; }

        public int EventId { get; set; }

        public Guid  AccountId { get; set; }

        public DateTime DataPublish { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual User Account { get; set; }

        public virtual ICollection<ContentPublishEvent> ContentPublishEvent { get; set; }

        [ForeignKey(nameof(EventId))]
        public virtual Event Event { get; set; }
    }
}
