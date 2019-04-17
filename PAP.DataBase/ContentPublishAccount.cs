namespace PAP.DataBase
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ContentPublishAccount
    {
        public ContentPublishAccount()
        {
            PhotoContentPublishAccount = new HashSet<PhotoContentPublishAccount>();
            FeedBackContentAccount = new HashSet<FeedBackContentAccount>();
            VideoContentPublishAccount = new HashSet<VideoContentPublishAccount>();
        }
        [Key]
        public int ContentPublishAccountId { get; set; }

        public int AccountPublishId { get; set; }

        public string TextContent { get; set; }

        [StringLength(500)]
        public string GithubFile { get; set; }

       
        public string Tags { get; set; }
        [ForeignKey(nameof(AccountPublishId))]
        public virtual AccountPublish AccountPublish { get; set; }

        public virtual ICollection<PhotoContentPublishAccount> PhotoContentPublishAccount { get; set; }

        public virtual ICollection<FeedBackContentAccount> FeedBackContentAccount { get; set; }

        public virtual ICollection<VideoContentPublishAccount> VideoContentPublishAccount { get; set; }
    }
}
