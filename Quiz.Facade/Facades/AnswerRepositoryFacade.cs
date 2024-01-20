using Quiz.Logic;
using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;

namespace Quiz.Facade.Facades
{
    public class AnswerRepositoryFacade : RepositoryFacade<Answer>
    {
        public AnswerRepositoryFacade(RepositoryFactory factory) : base(factory)
        {
        }

        public override Task<Response<Answer>> Add(Answer data)
        {
            throw new NotImplementedException();
        }

        public override Task<Response<Answer>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<Response<Answer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<Response<Answer>> Update(Answer data)
        {
            throw new NotImplementedException();
        }
    }

}
