namespace PAP.DataBase
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FeedBackContentAccount
    {
        [Key]
        public int FeedBackContentAccountId { get; set; }

        public int ContentPublishAccountId { get; set; }

        public int AccountId { get; set; }

        public int Emotion { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int Stars { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }

        [ForeignKey(nameof(ContentPublishAccountId))]
        public virtual ContentPublishAccount ContentPublishAccount { get; set; }
    }
}
