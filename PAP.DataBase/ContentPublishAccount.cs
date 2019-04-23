namespace PAP.DataBase
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ContentPublishAccount
    {  
        [Key]
        public int ContentPublishAccountId { get; set; }

        public int AccountPublishId { get; set; }

        public string TextContent { get; set; }

        [StringLength(500)]
        public string GithubFile { get; set; }

       
        public string Tags { get; set; }
        [ForeignKey(nameof(AccountPublishId))]
        public virtual AccountPublish AccountPublish { get; set; }
        [InverseProperty(nameof(PhotoContentPublishAccount.PhotoContentPublishAccountId))]
        public virtual ICollection<PhotoContentPublishAccount> PhotoContentPublishAccounts { get; set; }
        [InverseProperty(nameof(FeedBackContentAccount.FeedBackContentAccountId))]
        public virtual ICollection<FeedBackContentAccount> FeedBackContentAccounts { get; set; }
        [InverseProperty(nameof(VideoContentPublishAccount.VideoContentPublishAccountId))]
        public virtual ICollection<VideoContentPublishAccount> VideoContentPublishAccounts { get; set; }
    }
}
