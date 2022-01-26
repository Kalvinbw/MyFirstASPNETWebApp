﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission4.Models;

namespace mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieFormContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieFormContext mfc)
        {
            _logger = logger;
            _movieContext = mfc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieForm mf)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _movieContext.Add(mf);
            _movieContext.SaveChanges();

            return View("Confirmation", mf);
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
