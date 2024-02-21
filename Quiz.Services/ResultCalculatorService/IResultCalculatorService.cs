using Quiz.Models.FormattedData;
using Quiz.Models.ResponseModels;
using Quiz.Models.ViewModels;

namespace Quiz.Services.ResultCalculatorService
{
    public interface IResultCalculatorService
    {
        public Task<Response<QuizResultData>> CalculateResult(QuizViewModel data, int quizId);
    }
}
