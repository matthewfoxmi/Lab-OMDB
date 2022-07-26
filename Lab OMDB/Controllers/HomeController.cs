using Lab_OMDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab_OMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        MovieDAL movieDAL = new MovieDAL();

        List<MovieModel> movieList = new List<MovieModel>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet] //run by default, will just bring you to page
        public IActionResult Index()
        {
            return View();
        }

        //run when searching
        [HttpPost] //recevies search, will call DAL, get search term, grab result, display View


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet] //run when first get to page
        public IActionResult MovieSearch() //overloading: 1 method has parameters, 1 does not
        {
            return View();
        }

        [HttpPost] //run after submitting form
        public IActionResult MovieSearch(string title)
        {
            MovieModel result = movieDAL.GetMovie(title);
            return View(result);
        }

        [HttpGet] //run when first get to page
        public IActionResult MovieNight() //overloading: 1 method has parameters, 1 does not
        {
            return View();
        }

        [HttpPost] //run after submitting form
        public IActionResult MovieNight(string title1, string title2, string title3)
        {
            List<MovieModel> movies = new List<MovieModel>()
            //adds each title to list
            {
                 movieDAL.GetMovie(title1),
                 movieDAL.GetMovie(title2),
                 movieDAL.GetMovie(title3)
            };

            return View(movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}