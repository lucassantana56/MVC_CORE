namespace PAP.DataBase
{
  
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ContentPublishEvent
    {
        public ContentPublishEvent()
        {
            FeedBackContentEvent = new HashSet<FeedBackContentEvent>();
            PhotoContentPublishEvent = new HashSet<PhotoContentPublishEvent>();
        }
        [Key]
        public int ContentPublishEventId { get; set; }

        public int PublishEventId { get; set; }

        public string TextContent { get; set; }

        [StringLength(500)]
        public string  GithubFile { get; set; }
        [ForeignKey(nameof(PublishEventId))]
        public virtual PublishEvent PublishEvent { get; set; }

        public virtual ICollection<FeedBackContentEvent> FeedBackContentEvent { get; set; }

        public virtual ICollection<PhotoContentPublishEvent> PhotoContentPublishEvent { get; set; }
        
        public virtual ICollection<VideoContentPublishEvent> VideoContentPublishEvent { get; set; }
    }
}
