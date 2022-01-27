﻿// <auto-generated />
using System;
using Bookshop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookshop.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220126204815_AddedImagesForBooks")]
    partial class AddedImagesForBooks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookShop.Models.Author", b =>
                {
                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Guid");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookShop.Models.Book", b =>
                {
                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Guid");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookShop.Models.BookAuthor", b =>
                {
                    b.Property<string>("BookGuid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorGuid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BookGuid", "AuthorGuid");

                    b.HasIndex("AuthorGuid");

                    b.ToTable("BooksAuthors");
                });

            modelBuilder.Entity("BookShop.Models.BookAuthor", b =>
                {
                    b.HasOne("BookShop.Models.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.Models.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookShop.Models.Author", b =>
                {
                    b.Navigation("AuthorBooks");
                });

            modelBuilder.Entity("BookShop.Models.Book", b =>
                {
                    b.Navigation("BookAuthors");
                });
#pragma warning restore 612, 618
        }
    }
}
