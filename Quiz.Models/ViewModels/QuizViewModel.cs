using Quiz.Models.DataModels;

namespace Quiz.Models.ViewModels
{
    public class QuizViewModel
    {
        public DataModels.Quiz Quiz { get; set;}
        public Dictionary<int, Dictionary<int, bool>> QuestionPool { get; set;}
        public QuizViewModel(DataModels.Quiz quiz)
        {
            Quiz = quiz;

            QuestionPool = quiz.questions.ToDictionary(x => x.id, x => x.answers.ToDictionary(c => c.id, c => false));
        }
        public QuizViewModel() { }
    }
}
