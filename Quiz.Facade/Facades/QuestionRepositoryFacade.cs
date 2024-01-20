using Quiz.Logic;
using Quiz.Models.DataModels;

namespace Quiz.Facade.Facades
{
    public class QuestionRepositoryFacade : RepositoryFacade<Answer>
    {
        public QuestionRepositoryFacade(RepositoryFactory factory) : base(factory)
        {
        }
    }
}
