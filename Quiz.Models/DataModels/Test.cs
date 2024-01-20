using Quiz.Models.DataModels;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models.DataModels
{
    public class Test : IDataModel
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public DateTime creationDate { get; set; }
        public virtual List<Question> questions { get; set; }
    }
}
