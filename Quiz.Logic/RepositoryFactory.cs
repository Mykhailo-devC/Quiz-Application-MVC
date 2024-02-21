using Quiz.DB;
using Quiz.Logic.DataRepositories;
using Quiz.Logic.Interfaces;
using Quiz.Models.DataModels;

namespace Quiz.Logic
{
    public  class RepositoryFactory
    {
        private readonly QuizDbContext _context;

        public RepositoryFactory(QuizDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseDataModel
        {
            if(Enum.TryParse(typeof(T).Name, out RepositoryType repositoryType))
            {
                if (repositoryType == RepositoryType.Answer)
                {
                    return (IRepository<T>)new AnswerRepository(_context);
                }
                if (repositoryType == RepositoryType.Question)
                {
                    return (IRepository<T>)new QuestionRepository(_context);
                }
                if (repositoryType == RepositoryType.Quiz)
                {
                    return (IRepository<T>)new QuizRepository(_context);
                }
            }

            return null;
        }
    }
}
