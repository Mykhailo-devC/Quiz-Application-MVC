using Quiz.Models.DataModels;
using System.Collections;

namespace Quiz.Models.ResponseModels
{
    public class Response<T>
    {
        public bool Success { get; set; } = false;
        public new ICollection<T> Data { get; set; } = null;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
