using Quiz.Models.DataModels;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models.DataModels
{
    public class Question : IDataModel
    {
        public int id { get; set; }
        [Required]
        public string value { get; set; }
        [Required]
        public string correctAnswer { get; set; }
        public virtual ICollection<Answer> answers { get; set; }
        public int testId { get; set; }
        public Test test { get; set; }
        
    }
}