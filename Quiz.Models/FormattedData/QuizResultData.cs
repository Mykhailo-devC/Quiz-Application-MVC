namespace Quiz.Models.FormattedData
{
    public class QuizResultData
    {
        public string Name { get; set; }
        public int TotalNumberOfQuestions { get; set; }
        public int TotalNumberOfCorrectAnswers { get; set; }
        public string FinishedAtTime { get; set; }

        public string progressColor { get; set; }
        public int progressValue { get; set; }
    }
}
