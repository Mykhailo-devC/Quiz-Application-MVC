using Microsoft.EntityFrameworkCore;
using Quiz.DB;
using Quiz.Logic.Interfaces;
using Quiz.Models.DataModels;

namespace Quiz.Logic.DataRepositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(QuizDbContext context) : base(context)
        {
        }

        protected override async Task<Question?> FindItem(int id)
        {
            return await _dbSet.Include(x => x.answers)
                .FirstOrDefaultAsync(x => x.id == id);
        }
    }

}
