namespace PAP.DataBase
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class AccountNotifications
    {
        public int AccountNotificationsId { get; set; }

        public int SenderAccountId { get; set; }

        public int EventId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        [Column(TypeName = "date")]
        public DateTime NotificationsDate { get; set; }

        public string RedirectUrl { get; set; }

        public bool Seen { get; set; }

        public int ReceiverAccountId { get; set; }

        public virtual Account Account { get; set; }

        public virtual Event Event { get; set; }
    }
}
