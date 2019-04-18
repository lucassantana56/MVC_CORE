namespace PAP.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PublishEvent
    {

        public PublishEvent()
        {
            ContentPublishEvent = new HashSet<ContentPublishEvent>();
        }
        [Key]
        public int PublishEventId { get; set; }

        public int EventId { get; set; }

        
        public DateTime DataPublish { get; set; }

  
        public virtual ICollection<ContentPublishEvent> ContentPublishEvent { get; set; }

        [ForeignKey(nameof(EventId))]
        public virtual Event Event { get; set; }
    }
}
