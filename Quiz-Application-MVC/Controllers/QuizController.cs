using Microsoft.AspNetCore.Mvc;
using Quiz.Facade;
using Quiz.Facade.Facades;
using Quiz.Models.DataModels;
using Quiz.Models.FormattedData;
using Quiz.Models.ViewModels;
using Quiz.Services.ResultCalculatorService;

namespace Quiz_Application_MVC.Controllers
{
    public class QuizController : Controller
    {
        private readonly IRepositoryFacade<QuizFormattedData, Quiz.Models.DataModels.Quiz> _facade;
        private readonly IResultCalculatorService _calculatorService;

        public QuizController(FacadeFactory factory,
            IResultCalculatorService calculatorService)
        {
            _facade = factory.GetFacade<QuizFormattedData, Quiz.Models.DataModels.Quiz>();
            _calculatorService = calculatorService;
        }

        public async Task<IActionResult> StartQuiz([FromRoute] int id)
        {
            var quiz = await _facade.GetById(id);

            var viewModel = new QuizViewModel(quiz.Data.First());
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> FinishQuiz(QuizViewModel viewModel, [FromRoute] int id)
        {
            var response = await _calculatorService.CalculateResult(viewModel, id);

            if (!response.Success)
            {
                return NotFound(response.ErrorMessage);
            }

            var data = response.Data.FirstOrDefault();

            return View("QuizResults", data);
        }
    }
}
