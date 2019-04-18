namespace PAP.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    
    public partial class Event
    {
        public Event()
        {
            AccountNotifications = new HashSet<AccountNotifications>();
            AccountOnEvent = new HashSet<AccountOnEvent>();
            EventAccount = new HashSet<EventAccount>();
            PublishEvent = new HashSet<PublishEvent>();
        }
        [Key]
        public int EventId { get; set; }

        [StringLength(20)]
        public string NameEvent { get; set; }

       
        public DateTime DateCreated { get; set; }

      
        public DateTime DateEvent { get; set; }

        [StringLength(20)]
        public string TypeOfEvent { get; set; }
       
        public string LocationWhat3words { get; set; }

        [StringLength(500)]
        public string PhotoUrl { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? Stars { get; set; }

        public virtual ICollection<AccountNotifications> AccountNotifications { get; set; }

        public virtual ICollection<AccountOnEvent> AccountOnEvent { get; set; }

        public virtual ICollection<EventAccount> EventAccount { get; set; }

        public virtual ICollection<PublishEvent> PublishEvent { get; set; }
    }
}
