using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Facade
{
    public interface IRepositoryFacade<T> where T : class, IDataModel
    {
        public Task<Response<T>> GetAll();
        public Task<Response<T>> Add(T data);
        public Task<Response<T>> Update(T data);
        public Task<Response<T>> Delete(int id);
    }
}
