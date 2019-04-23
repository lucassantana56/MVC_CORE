using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PAP.DataBase;
using PAP.DataBase.Auth;
using System;

namespace PAP.Business.DbContext
{

    public class ApplicationDatabaseContext : IdentityDbContext<User, UserRole, Guid>
    {
        public ApplicationDatabaseContext(DbContextOptions options) : base(options)
        {
        }

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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(A => A.Stars)
                .HasDefaultValue(3);
            modelBuilder.Entity<Event>()
                .Property(E => E.Stars)
                .HasDefaultValue(3);
            modelBuilder.Entity<FeedBackContentAccount>()
                .Property(F => F.Stars)
                .HasDefaultValue(3);
            modelBuilder.Entity<FeedBackContentEvent>()
              .Property(F => F.Stars)
              .HasDefaultValue(3);
            modelBuilder.Entity<AccountRelationship>()
                .HasIndex(RA => new { RA.SenderAccountId, RA.ReceiverAccountId })
                .IsUnique();


            modelBuilder.Entity<AccountRelationship>()
                .HasOne(AR => AR.ReceiverAccount)
                .WithMany(x => x.ReceiverAccountRelationships)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccountRelationship>()
                .HasOne(AR => AR.SenderAccount)
                .WithMany(x => x.SenderAccountRelationships)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccountNotifications>()
              .HasIndex(RA => new { RA.SenderNotificationAccountId, RA.ReceiverNotificationAccountId })
              .IsUnique();

            modelBuilder.Entity<AccountNotifications>()
                .HasOne(AN => AN.ReceiverNotificationAccount )
                .WithMany(x => x.ReceiverNotificationAccounts)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccountNotifications>()
                .HasOne(AN => AN.SenderNotificationAccount)
                .WithMany(x => x.SenderNotificationAccount)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
