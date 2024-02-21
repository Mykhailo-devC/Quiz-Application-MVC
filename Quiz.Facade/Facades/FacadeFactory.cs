using Quiz.Logic;
using Quiz.Models.DataModels;

namespace Quiz.Facade.Facades
{
    public class FacadeFactory
    {
        private readonly RepositoryFactory _factory;

        public FacadeFactory(RepositoryFactory factory)
        {
            _factory = factory;
        }

        public IRepositoryFacade<T, K> GetFacade<T, K>() where K : BaseDataModel
        {
            var name = typeof(K).Name;
            var result = Enum.TryParse(name, out RepositoryType repositoryType);
            if (result)
            {
                if (repositoryType == RepositoryType.Quiz)
                {
                    return (IRepositoryFacade<T, K>)new QuizRepositoryFacade(_factory);
                }
            }

            return null;
        }
    }
}
