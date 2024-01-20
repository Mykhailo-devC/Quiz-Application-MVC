using Microsoft.EntityFrameworkCore;
using Quiz.Logic;
using Quiz.Logic.DataRepositories;
using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;

namespace Quiz.Facade
{
    public abstract class RepositoryFacade<T> : IRepositoryFacade<T> where T : class, IDataModel
    {
        protected IRepository<T> _repository;
        public RepositoryFacade(RepositoryFactory factory)
        {
            _repository = factory.GetRepository<T>();
        }
        public abstract Task<Response<T>> GetAll();

        public abstract Task<Response<T>> Add(T data);

        public abstract Task<Response<T>> Update(T data);

        public abstract Task<Response<T>> Delete(int id);
    }

}
