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

        public IRepositoryFacade<T> GetFacade<T>() where T : class, IDataModel
        {
            var repositoryType = typeof(T);

            if (repositoryType == typeof(Answer))
            {
                return (IRepositoryFacade<T>)new AnswerRepositoryFacade(_factory);
            }
            else if (repositoryType == typeof(Question))
            {
                return (IRepositoryFacade<T>)new QuestionRepositoryFacade(_factory);
            }
            else if (repositoryType == typeof(Test))
            {
                return (IRepositoryFacade<T>)new TestRepositoryFacade(_factory);
            }
            else
            {
                return null;
            }
        }
    }
}
