namespace PAP.Business.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using PAP.DataBase;


    public partial class Context : DbContext
    {
        public Context(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountNotifications> AccountNotifications { get; set; }
        public virtual DbSet<AccountOnEvent> AccountOnEvent { get; set; }
        public virtual DbSet<AccountPublish> AccountPublish { get; set; }
        public virtual DbSet<AccountRelationship> AccountRelationship { get; set; }
        public virtual DbSet<ContentPublishAccount> ContentPublishAccount { get; set; }
        public virtual DbSet<ContentPublishEvent> ContentPublishEvent { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventAccount> EventAccount { get; set; }
        public virtual DbSet<FeedBackContentAccount> FeedBackContentAccount { get; set; }
        public virtual DbSet<FeedBackContentEvent> FeedBackContentEvent { get; set; }
        public virtual DbSet<PhotoContentPublishAccount> PhotoContentPublishAccount { get; set; }
        public virtual DbSet<PhotoContentPublishEvent> PhotoContentPublishEvent { get; set; }
        public virtual DbSet<PublishEvent> PublishEvent { get; set; }
        public virtual DbSet<VideoContentPublishAccount> VideoContentPublishAccount { get; set; }
        public virtual DbSet<VideoContentPublishEvent> VideoContentPublishEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(A => A.Stars)
                .HasDefaultValue(3);
            modelBuilder.Entity<Event>()
                .Property(E => E.Stars)
                .HasDefaultValue(3);
            modelBuilder.Entity<FeedBackContentAccount>()
                .Property(F => F.Stars)
                .HasDefaultValue(3);
        }
    }
}
