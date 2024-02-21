using Microsoft.EntityFrameworkCore;
using Quiz.DB;
using Quiz.Logic.Interfaces;

namespace Quiz.Logic.DataRepositories
{
    public class QuizRepository : Repository<Models.DataModels.Quiz>, IQuizRepository
    {
        public QuizRepository(QuizDbContext context) : base(context)
        {
        }

        protected override async Task<Models.DataModels.Quiz?> FindItem(int id)
        {
            return await _dbSet.Include(x => x.questions)
                .ThenInclude(x => x.answers)
                .FirstOrDefaultAsync(x => x.id == id);
        }

        protected override async Task<IList<Models.DataModels.Quiz>> GetAllItems()
        {
            return await _dbSet.Include(x => x.questions)
                .ThenInclude(x => x.answers)
                .ToListAsync();
        }

        protected override async Task<Models.DataModels.Quiz> UpdateItem(Models.DataModels.Quiz item)
        {
            var itemToUpdate = await FindItem(item.id);

            itemToUpdate.name = item.name;
            itemToUpdate.questions = item.questions;

            var questions = _context.Questions
                .Where(x => x.quizId == item.id)
                .ToList()
                .Where(x => !item.questions.Any(c => c.id == x.id))
                .ToList();

            _context.Questions.RemoveRange(questions);

            return itemToUpdate;
        }
    }
}
