using Quiz.Models.DataModels;
using Quiz.Models.ViewModels;

namespace Quiz.Services.ModelPreparatorService
{
    public class QuizViewModelPreparator : IQuizViewModelPreparator
    {
        public ManageQuizViewModel GetNewViewModel()
        {
            var viewModel = new ManageQuizViewModel();
            AddQuestionToViewModel(viewModel, 0);
            return viewModel;
        }

        public void AddQuestionToViewModel(ManageQuizViewModel model, int questionId)
        {
            model.Quiz.questions.Add(new Question());
            AddAnswerToViewModel(model, questionId);
        }
        public void AddAnswerToViewModel(ManageQuizViewModel model, int questionId)
        {
            model.Quiz.questions[questionId].answers.Add(new Answer());
        }

        public void DeleteQuestionFromViewModel(ManageQuizViewModel model, int questionId)
        {
            model.Quiz.questions.RemoveAt(questionId);
        }
        public void DeleteAnswerFromViewModel(ManageQuizViewModel model, int questionId, int answerId)
        {
            model.Quiz.questions[questionId].answers.RemoveAt(answerId);
        }
    }
}
