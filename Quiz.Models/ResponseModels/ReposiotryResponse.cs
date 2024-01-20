using Quiz.Models.DataModels;

namespace Quiz.Models.ResponseModels
{
    public class ReposiotryResponse<T> : Response<T> where T : class, IDataModel
    {

    }

    public class Response<T>
    {
        public bool Success { get; set; } = false;
        public ICollection<T> Data { get; set; } = null;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
