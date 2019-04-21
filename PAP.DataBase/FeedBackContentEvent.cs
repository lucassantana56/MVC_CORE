namespace PAP.DataBase
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FeedBackContentEvent
    {
        [Key]
        public int IdFeedBackContent { get; set; }

        public int ContentPublishEventId { get; set; }

        public int AccountId { get; set; }

        public int? Emotion { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }

        [ForeignKey(nameof(ContentPublishEventId))]
        public virtual ContentPublishEvent ContentPublishEvent { get; set; }
    }
}
