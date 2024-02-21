using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;


namespace Quiz.Facade
{
    public interface IRepositoryFacade<T, K> where K : BaseDataModel
    {
        public Task<Response<T>> GetAll();
        public Task<Response<K>> GetById(int id);
        public Task<Response<T>> Add(K data);
        public Task<Response<T>> Update(K data);
        public Task<Response<T>> Delete(int id);
    }
}
