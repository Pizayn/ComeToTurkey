using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ComeToTurkey.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ComeToTurkey.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Destination> Destinations { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
           

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(u => u.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(u => u.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Follow>()
                .HasKey(k => new { k.FollowerId, k.FollowingId });
            builder.Entity<Follow>()
                .HasOne(u => u.Following)
                .WithMany(u => u.Followers)
                .HasForeignKey(u => u.FollowingId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Follow>()
                .HasOne(u => u.Follower)
                .WithMany(u => u.Followings)
                .HasForeignKey(u => u.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Like>()
                .HasKey(k => new { k.LikerId, k.BlogLikeId });
            builder.Entity<Like>()
                .HasOne(u => u.BlogLike)
                .WithMany(u => u.BlogLikes)
                .HasForeignKey(u => u.BlogLikeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Like>()
                .HasOne(u => u.Liker)
                .WithMany(u => u.Likers)
                .HasForeignKey(u => u.LikerId)
                .OnDelete(DeleteBehavior.Restrict);





            builder.Entity<Comment>()
                .HasOne(u => u.Sender)
                .WithMany(u => u.CommentsSent)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comment>()
                .HasOne(u => u.Recipient)
                .WithMany(u => u.CommentsReceived)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
