﻿using Microsoft.AspNetCore.Mvc;
using Quiz.DB;
using Quiz.Facade;
using Quiz.Logic;
using Quiz.Models.DataModels;
using Quiz_Application_MVC.Models;
using System.Diagnostics;

namespace Quiz_Application_MVC.Controllers
{
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly IRepositoryFacade<Test> _facade;

        public MainController(ILogger<MainController> logger, FacadeFactory factory)
        {
            _logger = logger;
            _facade = factory.GetFacade<Test>();
        }

        public async Task<IActionResult> Index()
        {
            var result = await _facade.GetAll();

            if (!result.Success)
            {
                return NotFound(result.ErrorMessage);
            }

            return View(result.Data);

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