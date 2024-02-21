using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Quiz.Models.DataModels;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models.ViewModels
{
    public class ManageQuizViewModel
    {
        public DataModels.Quiz Quiz { get; set; }

        [ValidateNever]
        public Question Question { get; set; }

        [ValidateNever]
        public Answer Answer { get; set; }
        public ManageQuizViewModel()
        {
            Quiz = new DataModels.Quiz();
            Question = new Question();
            Answer = new Answer();
        }
    }
}
