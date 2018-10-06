﻿// <auto-generated />
using System;
using BookLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookLibrary.Data.Migrations
{
    [DbContext(typeof(BookLibraryContext))]
    partial class BookLibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookLibrary.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookLibrary.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsBorrowed");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookLibrary.Models.BookBorrowers", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("BorrowerId");

                    b.Property<DateTime>("BorrowDate");

                    b.Property<bool>("IsBookReturned");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("BookId", "BorrowerId", "BorrowDate");

                    b.HasIndex("BorrowerId");

                    b.ToTable("BookBorrowerses");
                });

            modelBuilder.Entity("BookLibrary.Models.Borrower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("BookLibrary.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("BookLibrary.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("DirectorId");

                    b.Property<bool>("IsBorrowed");

                    b.Property<string>("PosterImageUrl");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("BookLibrary.Models.MovieBorrowers", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("BorrowerId");

                    b.Property<DateTime>("BorrowDate");

                    b.Property<bool>("IsMovieReturned");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("MovieId", "BorrowerId", "BorrowDate");

                    b.HasIndex("BorrowerId");

                    b.ToTable("MovieBorrowerses");
                });

            modelBuilder.Entity("BookLibrary.Models.Book", b =>
                {
                    b.HasOne("BookLibrary.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookLibrary.Models.BookBorrowers", b =>
                {
                    b.HasOne("BookLibrary.Models.Book", "Book")
                        .WithMany("Borrowerses")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookLibrary.Models.Borrower", "Borrower")
                        .WithMany("BorrowersedBooks")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookLibrary.Models.Movie", b =>
                {
                    b.HasOne("BookLibrary.Models.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookLibrary.Models.MovieBorrowers", b =>
                {
                    b.HasOne("BookLibrary.Models.Borrower", "Borrower")
                        .WithMany("BorrowersedMovies")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookLibrary.Models.Movie", "Movie")
                        .WithMany("Borrowerses")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}