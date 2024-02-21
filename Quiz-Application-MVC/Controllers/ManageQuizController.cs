using Microsoft.AspNetCore.Mvc;
using Quiz.Facade;
using Quiz.Facade.Facades;
using Quiz.Models.FormattedData;
using Quiz.Models.ResponseModels;
using Quiz.Models.ViewModels;
using Quiz.Services;
using Quiz.Services.ModelPreparatorService;

namespace Quiz_Application_MVC.Controllers
{
    public class ManageQuizController : Controller
    {
        private readonly ILogger<ManageQuizController> _logger;
        private readonly IRepositoryFacade<QuizFormattedData, Quiz.Models.DataModels.Quiz> _facade;
        private readonly IQuizViewModelPreparator _modelPreparator;
        private readonly TempDataStorage _storage;
        public ManageQuizController(ILogger<ManageQuizController> logger, FacadeFactory factory, IQuizViewModelPreparator modelPreparator, TempDataStorage storage)
        {
            _logger = logger;
            _facade = factory.GetFacade<QuizFormattedData, Quiz.Models.DataModels.Quiz>();
            _modelPreparator = modelPreparator;
            _storage = storage;
        }
        public IActionResult AddQuizView([FromQuery] string mode)
        {
            _storage.ManageMode = mode;

            var quizViewModel = _modelPreparator.GetNewViewModel();

            return View(quizViewModel);
        }

        public async Task<IActionResult> EditQuiz([FromRoute] int id, [FromQuery] string mode)
        {
            _storage.ManageMode = mode;

            var response = await _facade.GetById(id);

            if (!response.Success)
            {
                return NotFound();
            }

            var quizViewModel = new ManageQuizViewModel();
            quizViewModel.Quiz = response.Data.First();

            return View("AddQuizView", quizViewModel);
        }

        public async Task<IActionResult> DeleteQuiz([FromRoute] int id)
        {
            var response = await _facade.Delete(id);

            if (!response.Success)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Main");
        }

        [HttpPost]
        public IActionResult DeleteQuestion(ManageQuizViewModel model,[FromRoute] int id)
        {
            ModelState.Clear();

            _modelPreparator.DeleteQuestionFromViewModel(model, id);

            return View("AddQuizView", model);
        }

        [HttpPost]
        public IActionResult DeleteAnswer(ManageQuizViewModel model, [FromRoute] int id, [FromRoute] int questId)
        {
            ModelState.Clear();

            _modelPreparator.DeleteAnswerFromViewModel(model, questId, id);

            return View("AddQuizView", model);
        }

        [HttpPost]
        public IActionResult AddQuestion(ManageQuizViewModel model, [FromRoute] int id)
        {
            ModelState.Clear();

            _modelPreparator.AddQuestionToViewModel(model, id);

            return View("AddQuizView", model);
        }

        [HttpPost]
        public IActionResult AddAnswer(ManageQuizViewModel model, [FromRoute] int id)
        {
            ModelState.Clear();

            _modelPreparator.AddAnswerToViewModel(model, id);

            return View("AddQuizView", model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveQuizChanges(ManageQuizViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("AddQuizView", model);
            }

            Response<QuizFormattedData> response = new();

            if(_storage.ManageMode == "Create")
            {
                response = await _facade.Add(model.Quiz);
            }
            else if(_storage.ManageMode == "Update")
            {
                response = await _facade.Update(model.Quiz);
            }

            if (!response.Success)
            {
                TempData["ErrorMessage"] = response.ErrorMessage;
                return View("AddQuizView", model);
            }

            return RedirectToAction("Index", "Main");
        }
    }
}
