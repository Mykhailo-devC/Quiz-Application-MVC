using Quiz.Facade;
using Quiz.Facade.Facades;
using Quiz.Models.FormattedData;
using Quiz.Models.ResponseModels;
using Quiz.Models.ViewModels;

namespace Quiz.Services.ResultCalculatorService
{
    public class ResultCalculatorService : IResultCalculatorService
    {
        private readonly IRepositoryFacade<QuizFormattedData, Quiz.Models.DataModels.Quiz> _facade;

        public ResultCalculatorService(FacadeFactory factory)
        {
            _facade = factory.GetFacade<QuizFormattedData, Quiz.Models.DataModels.Quiz>();
        }

        public async Task<Response<QuizResultData>> CalculateResult(QuizViewModel data, int quizId)
        {
            var result = new Response<QuizResultData>();

            try
            {
                if(data != null)
                {
                    var quizResultData = new QuizResultData();
                    var response = await _facade.GetById(quizId);
                    
                    if (response.Success)
                    {
                        var quiz = response.Data.FirstOrDefault();
                        data.Quiz = quiz;

                        quizResultData.Name = quiz.name;
                        quizResultData.TotalNumberOfQuestions = quiz.questions.Count;
                        quizResultData.TotalNumberOfCorrectAnswers = CalculateNumberOfCorrectAnswers(data);
                        quizResultData.FinishedAtTime = DateTime.Now.ToShortTimeString();
                        quizResultData.progressValue = CalculateCorrectAnswerPercent(quizResultData.TotalNumberOfCorrectAnswers,
                                                                                     quizResultData.TotalNumberOfQuestions);
                        quizResultData.progressColor = CalculateProgressColor(quizResultData.progressValue);

                        result.Success = true;
                        result.Data.Add(quizResultData);

                    }
                    else
                    {
                        result.ErrorMessage = response.ErrorMessage;
                    }
                }
                else
                {
                    result.ErrorMessage = "Result data is empty";
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        private int CalculateNumberOfCorrectAnswers(QuizViewModel data)
        {
            int number = 0;

            foreach(var question in data.Quiz.questions)
            {
                var correctAnswer = question.answers.FirstOrDefault(x => x.value == question.correctAnswer);

                if (data.QuestionPool[question.id][correctAnswer.id] == true &&
                    data.QuestionPool[question.id].Any(x => x.Key != correctAnswer.id && x.Value == true) == false)
                {
                    number++;
                }
            }

            return number;
        }

        public int CalculateCorrectAnswerPercent(int numberOfCorrectAnswers, int totalNumberOfQuestions)
        {
           return (int)Math.Round((double)(numberOfCorrectAnswers * 100) /
                                        totalNumberOfQuestions);
        }

        public string CalculateProgressColor(int progressValue)
        {
            string progressColor;

            if (progressValue > 75)
            {
                progressColor = "bg-primary";
            }
            else if (progressValue > 30)
            {
                progressColor = "bg-warning";
            }
            else
            {
                progressColor = "bg-danger";
            }

            return progressColor;
        }
    }
}
