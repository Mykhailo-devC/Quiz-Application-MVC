namespace Quiz.Models.ResponseModels
{
    public class Response<T>
    {
        public bool Success { get; set; } = false;
        public ICollection<T> Data { get; set; } = new List<T>();
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
