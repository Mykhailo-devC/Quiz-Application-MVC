using Microsoft.EntityFrameworkCore;
using Quiz.Logic;
using Quiz.Logic.DataRepositories;
using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;

namespace Quiz.Facade
{
    public abstract class RepositoryFacade<RepositoryT, DataT> : IRepositoryFacade<DataT> where RepositoryT : class, IDataModel
    {
        protected IRepository<RepositoryT> _mainRepository;
        public RepositoryFacade(RepositoryFactory factory)
        {
            _mainRepository = factory.GetRepository<RepositoryT>();
        }
        public abstract Task<Response<DataT>> GetAll();

        public abstract Task<Response<DataT>> Add(DataT data);

        public abstract Task<Response<DataT>> Update(DataT data);

        public abstract Task<Response<DataT>> Delete(int id);
    }

}
