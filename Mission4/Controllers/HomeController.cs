using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Mission5.Models;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieContext InfoContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext someName)
        {
            _logger = logger;
            InfoContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm ()
        {
            ViewBag.Categories = InfoContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar )
        {
            if (ModelState.IsValid)
            {
                InfoContext.Add(ar);
                InfoContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = InfoContext.Categories.ToList();
                return View(ar);
            }
        }

        public IActionResult MyPodcasts()
        {
            return View("MyPodcasts");
        }

        public IActionResult MovieList()
        {
            var movies = InfoContext.responses
                .Include(x => x.Category)
                .Where(x => x.Title != null)
                .Where(x => x.Year != 0)
                .Where(x => x.Director != null)
                .Where(x => x.Rating != null)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = InfoContext.Categories.ToList();

            var application = InfoContext.responses.Single(x => x.ApplicationId == applicationid);

            return View("MovieForm", application);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationResponse passedIn)
        {
            InfoContext.Update(passedIn);
            InfoContext.SaveChanges();

            return RedirectToAction("MovieList");
        }


        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var application = InfoContext.responses.Single(x => x.ApplicationId == applicationid);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            InfoContext.responses.Remove(ar);
            InfoContext.SaveChanges();
            return RedirectToAction("MovieList");
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
