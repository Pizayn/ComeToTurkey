﻿// <auto-generated />
using System;
using ComeToTurkey.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComeToTurkey.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191202225906_destination")]
    partial class destination
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComeToTurkey.API.Models.About", b =>
                {
                    b.Property<int>("AboutId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("AboutId");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogCategoryId");

                    b.Property<int>("CityId");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Description");

                    b.Property<string>("MainPhotoUrl");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("BlogId");

                    b.HasIndex("BlogCategoryId");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.BlogCategory", b =>
                {
                    b.Property<int>("BlogCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogCategoryName");

                    b.HasKey("BlogCategoryId");

                    b.ToTable("BlogCategories");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<bool>("IsDeletedByRecipient");

                    b.Property<bool>("IsDeletedBySender");

                    b.Property<int>("RecipientId");

                    b.Property<DateTime>("SendDate");

                    b.Property<int>("SenderId");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<string>("MainPhotoUrl");

                    b.Property<string>("RegionName");

                    b.Property<string>("Text");

                    b.HasKey("DestinationId");

                    b.HasIndex("CityId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Follow", b =>
                {
                    b.Property<int>("FollowerId");

                    b.Property<int>("FollowingId");

                    b.HasKey("FollowerId", "FollowingId");

                    b.HasIndex("FollowingId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Like", b =>
                {
                    b.Property<int>("LikerId");

                    b.Property<int>("BlogLikeId");

                    b.HasKey("LikerId", "BlogLikeId");

                    b.HasIndex("BlogLikeId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime?>("DateRead");

                    b.Property<bool>("IsDeletedByRecipient");

                    b.Property<bool>("IsDeletedBySender");

                    b.Property<bool>("IsRead");

                    b.Property<int>("RecipientId");

                    b.Property<DateTime>("SendDate");

                    b.Property<int>("SenderId");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.New", b =>
                {
                    b.Property<int>("NewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Description");

                    b.Property<string>("MainPhotoUrl");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.HasKey("NewId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("IsMain");

                    b.Property<string>("PublicId");

                    b.Property<string>("Url");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhotoUrl");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutMe");

                    b.Property<string>("CountryId");

                    b.Property<int?>("CountryId1");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<DateTime>("LastActive");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Status");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("CountryId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Blog", b =>
                {
                    b.HasOne("ComeToTurkey.API.Models.BlogCategory", "BlogCategory")
                        .WithMany("Blogs")
                        .HasForeignKey("BlogCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ComeToTurkey.API.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ComeToTurkey.API.Models.User", "User")
                        .WithMany("Blogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Comment", b =>
                {
                    b.HasOne("ComeToTurkey.API.Models.Blog", "Recipient")
                        .WithMany("CommentsReceived")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ComeToTurkey.API.Models.User", "Sender")
                        .WithMany("CommentsSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Destination", b =>
                {
                    b.HasOne("ComeToTurkey.API.Models.City", "City")
                        .WithMany("Destinations")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Follow", b =>
                {
                    b.HasOne("ComeToTurkey.API.Models.User", "Follower")
                        .WithMany("Followings")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ComeToTurkey.API.Models.User", "Following")
                        .WithMany("Followers")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Like", b =>
                {
                    b.HasOne("ComeToTurkey.API.Models.Blog", "BlogLike")
                        .WithMany("BlogLikes")
                        .HasForeignKey("BlogLikeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ComeToTurkey.API.Models.User", "Liker")
                        .WithMany("Likers")
                        .HasForeignKey("LikerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Message", b =>
                {
                    b.HasOne("ComeToTurkey.API.Models.User", "Recipient")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ComeToTurkey.API.Models.User", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.Photo", b =>
                {
                    b.HasOne("ComeToTurkey.API.Models.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ComeToTurkey.API.Models.User", b =>
                {
                    b.HasOne("ComeToTurkey.API.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId1");
                });
#pragma warning restore 612, 618
        }
    }
}
