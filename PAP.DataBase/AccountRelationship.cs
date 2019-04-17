namespace PAP.DataBase
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AccountRelationship
    {
   
        public AccountRelationship()
        {
            AccountPublish = new HashSet<AccountPublish>();
        }
        [Key]
        public int AccountRelationshipId { get; set; }
        [Required]
        public int SenderAccountId { get; set; }
        [Required]
        public int ReceiverAccount { get; set; }
  
        public bool Isfriend { get; set; }

        [ForeignKey(nameof(ReceiverAccount))]
        public virtual Account Account { get; set; }
        
        public virtual ICollection<AccountPublish> AccountPublish { get; set; }
    }
}
