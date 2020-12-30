using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBD_TO_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
          
        }

        public DbSet<Genre> Genre { get; set; }                     //ok
        public DbSet<Movie> Movie { get; set; }                     //ok

        public DbSet<MovieGenre> MovieGenre { get; set; }           //ok
        public DbSet<ActorMovie> ActorMovie { get; set; }           //ok
        //public DbSet<CinemaEmployee> CinemaEmployee { get; set; }     //ok

        public DbSet<Schedule> Schedule { get; set; }               //ok
        public DbSet<Seat> Seat { get; set; }                       //ok
        public DbSet<ScreeningRoom> ScreeningRoom { get; set; }     //ok
        public DbSet<ScheduleEntry> ScheduleEntry { get; set; }     //ok
        public DbSet<Reservation> Reservation { get; set; }         //ok
        public DbSet<Payment> Payment { get; set; }                 //ok
        public DbSet<Order> Order { get; set; }                     //ok

        public DbSet<Address> Address { get; set; }                 //ok
        public DbSet<Cinema> Cinema { get; set; }                   //ok
        public DbSet<MovieStudio> MovieStudio { get; set; }          //ok

        public DbSet<Person> Person { get; set; }                   //ok
        public DbSet<User> User { get; set; }                       //ok
        public DbSet<Actor> Actor { get; set; }                     //ok
        public DbSet<Director> Director { get; set; }               //ok
        public DbSet<Employee> Employee { get; set; }               //ok
        public DbSet<Customer> Customer { get; set; }               //ok

        public DbSet<Comment> Comment { get; set; }                 //ok
        public DbSet<Complaint> Complaint { get; set; }             //ok
    }
}
