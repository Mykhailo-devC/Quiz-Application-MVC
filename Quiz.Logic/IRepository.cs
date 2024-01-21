﻿using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;

namespace Quiz.Logic
{
    public interface IRepository<T> where T : class, IDataModel
    { 
        public Task<Response<T>> GetAll();
        public Task<Response<T>> Add(T data);
        public Task<Response<T>> Update(T data);
        public Task<Response<T>> Delete(int id);
    }
}
