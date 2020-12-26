﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SBD_TO_Project.Data;

namespace SBD_TO_Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SBD_TO_Project.Models.ActorMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

                    b.Property<string>("ApartmentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
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
                });

            modelBuilder.Entity("SBD_TO_Project.Models.CinemaEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCinema")
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
                        .UseIdentityColumn();

                    b.Property<int?>("IdMovie")
                        .HasColumnType("int");

                    b.Property<int?>("IdSchedule")
                        .HasColumnType("int");

                    b.Property<int?>("IdScreeningRoom")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

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
                        .UseIdentityColumn();

                    b.Property<int?>("IdCinema")
                        .HasColumnType("int");

                    b.Property<int>("ScreeningRoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCinema");

                    b.ToTable("ScreeningRoom");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("IdScreeningRoom")
                        .HasColumnType("int");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Cinema");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.MovieStudio", b =>
                {
                    b.HasBaseType("SBD_TO_Project.Models.Address");

                    b.Property<DateTime>("EstablishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("MovieStudio");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Actor", b =>
                {
                    b.HasBaseType("SBD_TO_Project.Models.Person");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Director", b =>
                {
                    b.HasBaseType("SBD_TO_Project.Models.Person");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Director");
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
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Customer", b =>
                {
                    b.HasBaseType("SBD_TO_Project.Models.User");

                    b.Property<bool>("IsRegularCustomer")
                        .HasColumnType("bit");

                    b.ToTable("Customer");
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

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.CinemaEmployee", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Cinema", "Cinema")
                        .WithMany("CinemaEmployees")
                        .HasForeignKey("IdCinema");

                    b.HasOne("SBD_TO_Project.Models.Employee", "Employee")
                        .WithMany("CinemaEmployees")
                        .HasForeignKey("IdEmployee");

                    b.Navigation("Cinema");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Comment", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer");

                    b.HasOne("SBD_TO_Project.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("IdMovie");

                    b.Navigation("Customer");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Complaint", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer");

                    b.HasOne("SBD_TO_Project.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("IdOrder");

                    b.Navigation("Customer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Movie", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Director", "Director")
                        .WithMany()
                        .HasForeignKey("IdDirector");

                    b.HasOne("SBD_TO_Project.Models.MovieStudio", "MovieStudio")
                        .WithMany()
                        .HasForeignKey("IdMovieStudio");

                    b.Navigation("Director");

                    b.Navigation("MovieStudio");
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

                    b.Navigation("Genre");

                    b.Navigation("Movie");
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

                    b.Navigation("Payment");

                    b.Navigation("Reservation");
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

                    b.Navigation("Customer");

                    b.Navigation("ScheduleEntry");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Schedule", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Cinema", "Cinema")
                        .WithMany()
                        .HasForeignKey("IdCinema");

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.ScheduleEntry", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("IdMovie");

                    b.HasOne("SBD_TO_Project.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("IdSchedule");

                    b.HasOne("SBD_TO_Project.Models.ScreeningRoom", "ScreeningRoom")
                        .WithMany()
                        .HasForeignKey("IdScreeningRoom");

                    b.Navigation("Movie");

                    b.Navigation("Schedule");

                    b.Navigation("ScreeningRoom");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.ScreeningRoom", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Cinema", "Cinema")
                        .WithMany()
                        .HasForeignKey("IdCinema");

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Seat", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.ScreeningRoom", "ScreeningRoom")
                        .WithMany()
                        .HasForeignKey("IdScreeningRoom");

                    b.Navigation("ScreeningRoom");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Cinema", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Address", null)
                        .WithOne()
                        .HasForeignKey("SBD_TO_Project.Models.Cinema", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SBD_TO_Project.Models.MovieStudio", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Address", null)
                        .WithOne()
                        .HasForeignKey("SBD_TO_Project.Models.MovieStudio", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Actor", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("SBD_TO_Project.Models.Actor", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Director", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("SBD_TO_Project.Models.Director", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SBD_TO_Project.Models.User", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("SBD_TO_Project.Models.User", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Customer", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.User", null)
                        .WithOne()
                        .HasForeignKey("SBD_TO_Project.Models.Customer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Employee", b =>
                {
                    b.HasOne("SBD_TO_Project.Models.User", null)
                        .WithOne()
                        .HasForeignKey("SBD_TO_Project.Models.Employee", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Genre", b =>
                {
                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Movie", b =>
                {
                    b.Navigation("ActorMovies");

                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Cinema", b =>
                {
                    b.Navigation("CinemaEmployees");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Actor", b =>
                {
                    b.Navigation("ActorMovies");
                });

            modelBuilder.Entity("SBD_TO_Project.Models.Employee", b =>
                {
                    b.Navigation("CinemaEmployees");
                });
#pragma warning restore 612, 618
        }
    }
}
