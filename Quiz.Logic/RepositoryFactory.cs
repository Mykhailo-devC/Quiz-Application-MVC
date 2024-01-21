using Quiz.DB;
using Quiz.Logic.DataRepositories;
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

        public IRepository<T> GetRepository<T>() where T : class, IDataModel
        {
            var repositoryType = typeof(T);

            if(repositoryType == typeof(Answer))
            {
                return (IRepository<T>)new AnswerRepository(_context);
            }
            else if(repositoryType == typeof(Question))
            {
                return (IRepository<T>)new QuestionRepository(_context);
            }
            else if(repositoryType == typeof(Test))
            {
                return (IRepository<T>)new TestRepository(_context);
            }
            else
            {
                return null;
            }
        }
    }
}
