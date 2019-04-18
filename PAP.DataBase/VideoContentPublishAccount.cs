namespace PAP.DataBase
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class VideoContentPublishAccount
    {
        [Key]
        public int VideoContentPublishAccountId { get; set; }

        public int ContentPublishAccountId { get; set; }

        [StringLength(500)]
        public string VideoURl { get; set; }

        [ForeignKey(nameof(ContentPublishAccountId))]
        public virtual ContentPublishAccount ContentPublishAccount { get; set; }
    }
}
