using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;

namespace Quiz.Logic
{
    public interface IRepository<T> where T : class, IDataModel
    { 
        public Task<ReposiotryResponse<T>> GetAll();
        public Task<ReposiotryResponse<T>> Add(T data);
        public Task<ReposiotryResponse<T>> Update(T data);
        public Task<ReposiotryResponse<T>> Delete(int id);
    }
}
