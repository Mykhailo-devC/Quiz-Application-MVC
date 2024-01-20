using Microsoft.AspNetCore.Mvc;
using Quiz.DB;
using Quiz.Logic;
using Quiz.Models.DataModels;
using Quiz_Application_MVC.Models;
using System.Diagnostics;

namespace Quiz_Application_MVC.Controllers
{
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly IRepository<Answer> _repository;

        public MainController(ILogger<MainController> logger, RepositoryFactory factory)
        {
            _logger = logger;
            _repository = factory.GetRepository<Answer>();
        }

        public async Task<IActionResult> Index()
        {
            var result = await _repository.GetAll();

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