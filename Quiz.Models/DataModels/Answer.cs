using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Quiz.Models.DataModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models.DataModels
{
    public class Answer : BaseDataModel
    {
        [Required]
        [DisplayName("Answer")]
        public string value { get; set; }
        public int questionId { get; set; }
        [ValidateNever]
        public virtual Question question { get; set; }
    }
}
