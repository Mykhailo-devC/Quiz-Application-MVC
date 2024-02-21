using Quiz.Logic;
using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;

namespace Quiz.Facade
{
    public abstract class RepositoryFacade<T, K> : IRepositoryFacade<T, K> where K : BaseDataModel
    {
        public RepositoryFacade(RepositoryFactory factory)
        {

        }
        public abstract Task<Response<T>> GetAll();

        public abstract Task<Response<K>> GetById(int id);

        public abstract Task<Response<T>> Add(K data);

        public abstract Task<Response<T>> Update(K data);

        public abstract Task<Response<T>> Delete(int id);
    }

}
