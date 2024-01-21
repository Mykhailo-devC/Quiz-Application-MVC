using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;


namespace Quiz.Facade
{
    public interface IRepositoryFacade<T, K>
    {
        public Task<Response<T>> GetAll();
        public Task<Response<T>> Add(K data);
        public Task<Response<T>> Update(K data);
        public Task<Response<T>> Delete(int id);
    }
}
