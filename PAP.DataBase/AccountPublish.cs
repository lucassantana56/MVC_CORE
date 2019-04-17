namespace PAP.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AccountPublish
    {
     
        public AccountPublish()
        {
            ContentPublishAccount = new HashSet<ContentPublishAccount>();
        }
        [Key]
        public int AccountPublishId { get; set; }

        public int AccountId { get; set; }

        public int AccountRelationshipId { get; set; }

      
        public DateTime DatePublish { get; set; }

        [StringLength(1)]
        public string PublishPrivacy { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }

      
        public virtual ICollection<ContentPublishAccount> ContentPublishAccount { get; set; }

        [ForeignKey(nameof(AccountRelationshipId))]
        public virtual AccountRelationship AccountRelationship { get; set; }
    }
}
