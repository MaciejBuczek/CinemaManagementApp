using Microsoft.EntityFrameworkCore;
using SBD_TO_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
          
        }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movie { get; set; }

        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<ActorMovie> ActorMovie { get; set; }
        public DbSet<CinemaManager> CinemaMenager { get; set; }
        public DbSet<MovieStudio> MovieStudo { get; set; }

        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<ScreeningRoom> ScreeningRoom { get; set; }
        public DbSet<ScheduleEntry> ScheduleEntry { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<Address> Address { get; set; }
        public DbSet<Cinema> Cinema { get; set; }

        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Comment> Comment { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
    }
}
