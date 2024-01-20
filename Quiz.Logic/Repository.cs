using Quiz.DB;
using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;

namespace Quiz.Logic
{
    public abstract class Repository<T> : IRepository<T> where T : class, IDataModel
    {
        protected QuizDbContext _context;
        public Repository(QuizDbContext context)
        {
            _context = context;
        }

        public abstract Task<ReposiotryResponse<T>> GetAll();

        public abstract Task<ReposiotryResponse<T>> Add(T data);

        public abstract Task<ReposiotryResponse<T>> Update(T data);

        public abstract Task<ReposiotryResponse<T>> Delete(int id);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}