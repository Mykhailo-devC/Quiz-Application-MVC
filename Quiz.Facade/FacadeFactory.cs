using Quiz.Logic;
using Quiz.Models.DataModels;
using Quiz.Facade.Facades;

namespace Quiz.Facade
{
    public class FacadeFactory
    {
        private readonly RepositoryFactory _factory;

        public FacadeFactory(RepositoryFactory factory)
        {
            _factory = factory;
        }

        public IRepositoryFacade<T, K> GetFacade<T, K>()
        {
            var repositoryType = typeof(K);

/*            if (repositoryType == typeof(Answer))
            {
                return (IRepositoryFacade<T,K>)new AnswerRepositoryFacade(_factory);
            }
            if (repositoryType == typeof(Question))
            {
                return (IRepositoryFacade<T,K>)new QuestionRepositoryFacade(_factory);
            }*/
            if (repositoryType == typeof(Test))
            {
                return (IRepositoryFacade<T,K>)new TestRepositoryFacade(_factory);
            }
            else
            {
                return null;
            }
        }
    }
}
