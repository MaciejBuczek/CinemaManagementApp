using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models;
using SBD_TO_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<Movie> moviesFromReservations = _db.Reservation.Where(r => r.IdCustomer == _userManager.GetUserId(User)).Include(se => se.ScheduleEntry).
                ThenInclude(m => m.Movie).ThenInclude(mg => mg.MovieGenres).ThenInclude(g => g.Genre).Select(r => r.ScheduleEntry.Movie).ToList();

            List<Movie> allMovies = _db.Movie.Include(mg => mg.MovieGenres).ThenInclude(g => g.Genre).ToList();

            List<Movie> recommendedMovies = new List<Movie>();
            List<Movie> newestMovies = new List<Movie>();

            List<int[]> countOfGenre = new List<int[]>();

            if (allMovies.Count <= 5)
                newestMovies = allMovies;
            else
                for (int i = allMovies.Count - 1; i >= allMovies.Count - 5; i--)
                    newestMovies.Add(allMovies[i]);

            if (moviesFromReservations.Count > 0)
            {
                foreach(var genre in _db.Genre)
                {
                    countOfGenre.Add(new int[] { genre.Id, 0 });
                }
                foreach (var movie in moviesFromReservations)
                {
                    foreach (var movieGenre in movie.MovieGenres)
                    {
                        foreach(var count in countOfGenre)
                        {
                            if(count[0] == movieGenre.IdGenre)
                            {
                                count[1]++;
                                break;
                            }
                        }
                    }
                }
                int[] temp = { 0, 0 };
                foreach(var count in countOfGenre)
                {
                    if (count[1] > temp[1])
                        temp = count;
                }

                int[] temp2 = { 0, 0 };
                foreach (var count in countOfGenre)
                {
                    if (count[1] > temp2[1] && count != temp)
                        temp2 = count;
                }

                List<int> recommendedMoviesId = recommendedMovies.Select(m => m.Id).ToList();
                List<Movie> recommendationsByGenre = _db.MovieGenre.Include(g => g.Genre).Include(m => m.Movie).Where(g => g.IdGenre == temp[0] || g.IdGenre == temp2[0] && !recommendedMoviesId.Contains(g.IdMovie)).Select(m => m.Movie).Distinct().ToList();
                while (recommendationsByGenre.Count > 5)
                    recommendationsByGenre.RemoveAt(new Random().Next(0, recommendationsByGenre.Count - 1));
                recommendedMovies = recommendationsByGenre;
            }

            IndexMoviesVM indexMoviesVM = new IndexMoviesVM() { RecommendedMovies = recommendedMovies, NewestMovies = newestMovies };

            return View(indexMoviesVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
