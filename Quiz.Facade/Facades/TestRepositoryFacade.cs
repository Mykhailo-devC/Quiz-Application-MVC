using Quiz.Logic;
using Quiz.Models.DataModels;
using Quiz.Models.FormattedData;
using Quiz.Models.ResponseModels;

namespace Quiz.Facade.Facades
{
    public class TestRepositoryFacade : RepositoryFacade<TestFormattedData, Test>
    {
        private IRepository<Question> _questionRepository;
        private IRepository<Answer> _answerRepository;
        private IRepository<Test> _testRepository;
        public TestRepositoryFacade(RepositoryFactory factory) : base(factory)
        {
            _questionRepository = factory.GetRepository<Question>();
            _answerRepository = factory.GetRepository<Answer>();
            _testRepository = factory.GetRepository<Test>();
        }

        public override Task<Response<TestFormattedData>> Add(Test data)
        {
            throw new NotImplementedException();
        }

        public override Task<Response<TestFormattedData>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<Response<TestFormattedData>> GetAll()
        {
            var result = new Response<TestFormattedData>();
            try
            {
                var tests = await _testRepository.GetAll();
                if(tests != null)
                {
                    var questions = await _questionRepository.GetAll();
                    foreach(var test in tests.Data)
                    {
                        test.questions = questions.Data.Where(x => x.testId == test.id).ToList();
                    }

                    result.Data = tests.Data.Select(x => new TestFormattedData
                    {
                        Id = x.id,
                        Name = x.name,
                        CreationDate = x.creationDate.ToShortDateString(),
                        QuestionsCount = x.questions.Count
                    }).ToList();

                    result.Success = true;
                }
                else
                {
                    result.ErrorMessage = "There are no tests";
                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public override Task<Response<TestFormattedData>> Update(Test data)
        {
            throw new NotImplementedException();
        }
    }
}
