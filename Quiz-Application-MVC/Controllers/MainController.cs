using Microsoft.AspNetCore.Mvc;
using Quiz.Facade;
using Quiz.Facade.Facades;
using Quiz.Models.FormattedData;
using Quiz.Models.ViewModels;
using Quiz.Services.ModelPreparatorService;
using Quiz_Application_MVC.Models;
using System.Diagnostics;

namespace Quiz_Application_MVC.Controllers
{
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly IRepositoryFacade<QuizFormattedData, Quiz.Models.DataModels.Quiz> _facade;
        private readonly IQuizViewModelPreparator _modelPreparator;
        public MainController(ILogger<MainController> logger, FacadeFactory factory, IQuizViewModelPreparator modelPreparator)
        {
            _logger = logger;
            _facade = factory.GetFacade<QuizFormattedData, Quiz.Models.DataModels.Quiz>();
            _modelPreparator = modelPreparator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _facade.GetAll();

            if (!result.Success)
            {
                return NotFound(result.ErrorMessage);
            }

            var newQuiz = _modelPreparator.GetNewViewModel();
            ViewBag.NewQuiz = newQuiz;

            return View(result.Data);

        }

        
        [HttpPost]
        public async Task<IActionResult> AddQuizModal(ManageQuizViewModel quizViewModel)
        {
            quizViewModel.Quiz.questions.Add(quizViewModel.Question);
            quizViewModel.Question = null;
            return RedirectToAction("Index");
        }

        public IActionResult ShowAddQuizModal()
        {
            return RedirectToAction("Index");
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