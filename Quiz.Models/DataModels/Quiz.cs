using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models.DataModels
{
    public class Quiz : BaseDataModel
    {
        [Required]
        [DisplayName("Quiz name")]
        public string name { get; set; }
        public DateTime creationDate { get; set; }
        public virtual List<Question> questions { get; set; } = new();
    }
}
