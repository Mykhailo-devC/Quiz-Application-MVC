using Quiz.Models.ViewModels;

namespace Quiz.Services.ModelPreparatorService
{
    public interface IQuizViewModelPreparator
    {
        ManageQuizViewModel GetNewViewModel();
        void AddQuestionToViewModel(ManageQuizViewModel model, int questionId);
        void AddAnswerToViewModel(ManageQuizViewModel model, int questionId);
        void DeleteQuestionFromViewModel(ManageQuizViewModel model, int questionId);
        void DeleteAnswerFromViewModel(ManageQuizViewModel model, int questionId, int answerId);
    }
}
