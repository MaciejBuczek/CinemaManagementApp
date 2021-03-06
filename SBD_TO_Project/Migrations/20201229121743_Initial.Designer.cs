﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SBD_TO_Project.Data;

namespace SBD_TO_Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201229121743_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SBD_TO_Project.Models.ActorMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdActor")
                        .HasColumnType("int");

                    b.Property<int>("IdMovie")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdActor");

                    b.HasIndex("IdMovie");

                    b.ToTable("ActorMovie");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApartmentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Address");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.CinemaEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdCinema")
                        .HasColumnType("int");

                    b.Property<int?>("IdEmployee")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCinema");

                    b.HasIndex("IdEmployee");

                    b.ToTable("CinemaEmployee");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCustomer")
                        .HasColumnType("int");

                    b.Property<int?>("IdMovie")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdMovie");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Complaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComplaintContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdCustomer")
                        .HasColumnType("int");

                    b.Property<int?>("IdOrder")
                        .HasColumnType("int");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdOrder");

                    b.ToTable("Complaint");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgeRating")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdDirector")
                        .HasColumnType("int");

                    b.Property<int?>("IdMovieStudio")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Length")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDirector");

                    b.HasIndex("IdMovieStudio");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.MovieGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdGenre")
                        .HasColumnType("int");

                    b.Property<int>("IdMovie")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGenre");

                    b.HasIndex("IdMovie");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPayment")
                        .HasColumnType("int");

                    b.Property<int>("IdReservation")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPayment");

                    b.HasIndex("IdReservation");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCustomer")
                        .HasColumnType("int");

                    b.Property<int?>("IdScheduleEntry")
                        .HasColumnType("int");

                    b.Property<int?>("IdSeat")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdScheduleEntry");

                    b.HasIndex("IdSeat");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCinema")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCinema");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.ScheduleEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdMovie")
                        .HasColumnType("int");

                    b.Property<int>("IdSchedule")
                        .HasColumnType("int");

                    b.Property<int?>("IdScreeningRoom")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("IdMovie");

                    b.HasIndex("IdSchedule");

                    b.HasIndex("IdScreeningRoom");

                    b.ToTable("ScheduleEntry");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.ScreeningRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdCinema")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRows")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeatsPerRow")
                        .HasColumnType("int");

                    b.Property<string>("ScreeningRoomNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCinema");

                    b.ToTable("ScreeningRoom");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdScreeningRoom")
                        .HasColumnType("int");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<int>("RowNumber")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdScreeningRoom");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Cinema", b =>
                {
                    b.HasBaseType("SBD_TO_Project.Models.Address");

                    b.Property<DateTime>("CloseTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OpenTime")
                        .HasColumnType("datetime2");

                    b.ToTable("Cinema");

                    b.HasDiscriminator().HasValue("Cinema");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.MovieStudio", b =>
                {
                    b.HasBaseType("SBD_TO_Project.Models.Address");

                    b.Property<DateTime>("EstablishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("MovieStudio_Name")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("MovieStudio");

                    b.HasDiscriminator().HasValue("MovieStudio");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Actor", b =>
                {
                    b.HasBaseType("SBD_TO_Project.Models.Person");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Actor");

                    b.HasDiscriminator().HasValue("Actor");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Director", b =>
                {
                    b.HasBaseType("SBD_TO_Project.Models.Person");

                    b.Property<string>("Alias")
                        .HasColumnName("Director_Alias")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Director");

                    b.HasDiscriminator().HasValue("Director");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.User", b =>
                {
                    b.HasBaseType("SBD_TO_Project.Models.Person");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("SecurityLevel")
                        .HasColumnType("smallint");

                    b.ToTable("User");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Customer", b =>
                {
                    b.HasBaseType("SBD_TO_Project.Models.User");

                    b.Property<bool>("IsRegularCustomer")
                        .HasColumnType("bit");

                    b.ToTable("Customer");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Employee", b =>
                {
                    b.HasBaseType("SBD_TO_Project.Models.User");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdManager")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.ToTable("Employee");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.ActorMovie", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Actor", "Actor")
                        .WithMany("ActorMovies")
                        .HasForeignKey("IdActor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SBD_TO_Project.Models.Movie", "Movie")
                        .WithMany("ActorMovies")
                        .HasForeignKey("IdMovie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SBD_TO_Project.Models.CinemaEmployee", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Cinema", "Cinema")
                        .WithMany("CinemaEmployees")
                        .HasForeignKey("IdCinema");

                    b.HasOne("SBD_TO_Project.Models.Employee", "Employee")
                        .WithMany("CinemaEmployees")
                        .HasForeignKey("IdEmployee");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Comment", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer");

                    b.HasOne("SBD_TO_Project.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("IdMovie");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Complaint", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer");

                    b.HasOne("SBD_TO_Project.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("IdOrder");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Movie", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Director", "Director")
                        .WithMany()
                        .HasForeignKey("IdDirector");

                    b.HasOne("SBD_TO_Project.Models.MovieStudio", "MovieStudio")
                        .WithMany()
                        .HasForeignKey("IdMovieStudio");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.MovieGenre", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("IdGenre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SBD_TO_Project.Models.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("IdMovie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Order", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("IdPayment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SBD_TO_Project.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("IdReservation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Reservation", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer");

                    b.HasOne("SBD_TO_Project.Models.ScheduleEntry", "ScheduleEntry")
                        .WithMany()
                        .HasForeignKey("IdScheduleEntry");

                    b.HasOne("SBD_TO_Project.Models.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("IdSeat");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Schedule", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Cinema", "Cinema")
                        .WithMany()
                        .HasForeignKey("IdCinema")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SBD_TO_Project.Models.ScheduleEntry", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("IdMovie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SBD_TO_Project.Models.Schedule", "Schedule")
                        .WithMany("ScheduleEntries")
                        .HasForeignKey("IdSchedule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SBD_TO_Project.Models.ScreeningRoom", "ScreeningRoom")
                        .WithMany()
                        .HasForeignKey("IdScreeningRoom");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.ScreeningRoom", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Cinema", "Cinema")
                        .WithMany()
                        .HasForeignKey("IdCinema");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Seat", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.ScreeningRoom", "ScreeningRoom")
                        .WithMany("Seats")
                        .HasForeignKey("IdScreeningRoom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
