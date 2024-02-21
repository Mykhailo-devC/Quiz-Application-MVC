using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models.DataModels
{
    public class Question : BaseDataModel
    {
        [Required]
        [DisplayName("Question")]
        public string value { get; set; }
        [Required]
        [DisplayName("Correct Answer")]
        public string correctAnswer { get; set; }
        public virtual List<Answer> answers { get; set; } = new();
        public int quizId { get; set; }
        [ValidateNever]
        public Quiz quiz { get; set; }
        
    }
}