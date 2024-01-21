using Quiz.Logic;
using Quiz.Models.DataModels;
using Quiz.Models.FormattedData;
using Quiz.Models.ResponseModels;

namespace Quiz.Facade.Facades
{
    public class TestRepositoryFacade : RepositoryFacade<Test, TestFormattedData>
    {
        private IRepository<Question> _questionRepository;
        private IRepository<Answer> _answerRepository;
        public TestRepositoryFacade(RepositoryFactory factory) : base(factory)
        {
            _questionRepository = factory.GetRepository<Question>();
            _answerRepository = factory.GetRepository<Answer>();
        }

        public override Task<Response<TestFormattedData>> Add(TestFormattedData data)
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
                var tests = await _mainRepository.GetAll();
                if(tests != null)
                {
                    var questions = await _questionRepository.GetAll();
                    foreach(var test in tests.Data)
                    {
                        test.questions = questions.Data.Where(x => x.testId == test.id).ToList();
                        test.creationDate = test.creationDate;
                    }

                    var convertedData = tests.Data as ICollection<TestDTO>;

                    if (convertedData != null)
                    {
                        result.Data = convertedData;
                        result.Success = true;
                    }
                    else
                    {
                        result.ErrorMessage = "Can't convert test data to DTO object";
                    }
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
            return (Response<Test>)result;
        }

        public override Task<Response<TestFormattedData>> Update(Test data)
        {
            throw new NotImplementedException();
        }
    }
}
