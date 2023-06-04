﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230604123050_add-table")]
    partial class addtable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityLayer.Concrete.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutBackgroundImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutDetails1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutDetails2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutSmallImage1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutSmallImage2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AboutStatus")
                        .HasColumnType("bit");

                    b.Property<string>("CardDescription1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardDescription2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardDescription3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardDescription4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardTitle1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardTitle2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardTitle3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardTitle4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookAuthor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookBackCoverImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookCoverImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookPageCount")
                        .HasColumnType("int");

                    b.Property<string>("BookPublishingHouse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("BookStatus")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("BookID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("EntityLayer.Concrete.BookQuote", b =>
                {
                    b.Property<int>("BookQuoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<string>("BookQuoteContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BookQuoteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("BookQuoteStatus")
                        .HasColumnType("bit");

                    b.HasKey("BookQuoteID");

                    b.HasIndex("BookID");

                    b.ToTable("BookQuotes");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CategoryStatus")
                        .HasColumnType("bit");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CommentStatus")
                        .HasColumnType("bit");

                    b.Property<int>("ReadingActivityID")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("ReadingActivityID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ContactDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ContactStatus")
                        .HasColumnType("bit");

                    b.Property<string>("ContactSubject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ContactID");

                    b.HasIndex("UserID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ReadBook", b =>
                {
                    b.Property<int>("ReadBookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("BookReadStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReadBookReviewPoint")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReadingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ReadBookID");

                    b.HasIndex("BookID");

                    b.HasIndex("UserID");

                    b.ToTable("ReadBooks");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ReadingActivity", b =>
                {
                    b.Property<int>("ReadingActivityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivityContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ActivityCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ActivityFinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActivityImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ActivityStartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ActivityStatus")
                        .HasColumnType("bit");

                    b.Property<string>("ActivityTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.HasKey("ReadingActivityID");

                    b.HasIndex("AdminID");

                    b.HasIndex("BookID");

                    b.ToTable("ReadingActivities");
                });

            modelBuilder.Entity("EntityLayer.Concrete.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("RememberMe")
                        .HasColumnType("bit");

                    b.Property<string>("UserAbout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UserDateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UserStatus")
                        .HasColumnType("bit");

                    b.Property<string>("UserSurname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EntityLayer.Concrete.UserReadingActivity", b =>
                {
                    b.Property<int>("UserReadingActivityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookReviewScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<int>("ReadingActivityID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("UserReadingActivityID");

                    b.HasIndex("ReadingActivityID");

                    b.HasIndex("UserID");

                    b.ToTable("UserReadingActivities");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Book", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EntityLayer.Concrete.BookQuote", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Book", "Book")
                        .WithMany("Comments")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.HasOne("EntityLayer.Concrete.ReadingActivity", "ReadingActivity")
                        .WithMany()
                        .HasForeignKey("ReadingActivityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReadingActivity");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Contact", b =>
                {
                    b.HasOne("EntityLayer.Concrete.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ReadBook", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Book", "Book")
                        .WithMany("ReadBooks")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.User", "User")
                        .WithMany("ReadBooks")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ReadingActivity", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Admin", "Admin")
                        .WithMany("ReadingActivities")
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Book", "Book")
                        .WithMany("ReadingActivities")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("EntityLayer.Concrete.UserReadingActivity", b =>
                {
                    b.HasOne("EntityLayer.Concrete.ReadingActivity", "ReadingActivity")
                        .WithMany("UserReadingActivities")
                        .HasForeignKey("ReadingActivityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.User", "User")
                        .WithMany("UserReadingActivities")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReadingActivity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Admin", b =>
                {
                    b.Navigation("ReadingActivities");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Book", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ReadBooks");

                    b.Navigation("ReadingActivities");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ReadingActivity", b =>
                {
                    b.Navigation("UserReadingActivities");
                });

            modelBuilder.Entity("EntityLayer.Concrete.User", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("ReadBooks");

                    b.Navigation("UserReadingActivities");
                });
#pragma warning restore 612, 618
        }
    }
}
