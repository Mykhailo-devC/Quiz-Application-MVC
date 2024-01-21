using Quiz.Models.DataModels;
using System.Collections;

namespace Quiz.Models.ResponseModels
{
    public class ReposiotryResponse<T> : Response<T> where T : class, IDataModel
    {

    }

    public class Response<T> : Response
    {
        public new ICollection<T> Data { get; set; } = null;
    }

    public class Response
    {
        public bool Success { get; set; } = false;
        public ICollection Data { get; set; } = null;
        public string ErrorMessage { get; set; } = string.Empty;

        public ICollection<T> GetSpecifiedResponse<T>()
        {
            return (ICollection<T>)Data;
        }

    }
}
