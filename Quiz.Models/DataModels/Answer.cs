using Quiz.Models.DataModels;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models.DataModels
{
    public class Answer : IDataModel
    {
        public int id { get; set; }
        [Required]
        public string value { get; set; }
        public int questionId { get; set; }
        public virtual Question question { get; set; }
    }
}
