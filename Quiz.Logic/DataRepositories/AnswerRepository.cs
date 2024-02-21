using Quiz.DB;
using Quiz.Logic.Interfaces;
using Quiz.Models.DataModels;

namespace Quiz.Logic.DataRepositories
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(QuizDbContext context) : base(context)
        {
        }
    }
}
