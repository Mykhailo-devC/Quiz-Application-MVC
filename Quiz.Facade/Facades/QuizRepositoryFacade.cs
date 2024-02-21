using Quiz.Logic;
using Quiz.Logic.Interfaces;
using Quiz.Models.DataModels;
using Quiz.Models.FormattedData;
using Quiz.Models.ResponseModels;

namespace Quiz.Facade.Facades
{
    public class QuizRepositoryFacade : RepositoryFacade<QuizFormattedData, Models.DataModels.Quiz>
    {
        private IQuizRepository _testRepository;
        public QuizRepositoryFacade(RepositoryFactory factory) : base(factory)
        {
            _testRepository = (IQuizRepository)factory.GetRepository<Models.DataModels.Quiz>();
        }

        public override async Task<Response<QuizFormattedData>> Add(Models.DataModels.Quiz data)
        {
            var result = new Response<QuizFormattedData>();

            try
            {
                if(ValidateTestContent(data, out string errorMessage))
                {
                    data.creationDate = DateTime.Now;

                    var response = await _testRepository.Add(data);

                    if (response.Success)
                    {
                        var newQuiz = response.Data.FirstOrDefault();

                        if (newQuiz != null)
                        {
                            result.Success = true;
                        }
                        else
                        {
                            result.ErrorMessage = "Add operation return epmty data";
                        }

                    }
                    else
                    {
                        result.ErrorMessage = response.ErrorMessage;
                    }
                }
                else
                {
                    result.ErrorMessage = errorMessage;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public override async Task<Response<QuizFormattedData>> Delete(int id)
        {
            var result = new Response<QuizFormattedData>();

            try
            {
                var response = await _testRepository.Delete(id);

                if (response.Success)
                {
                    result.Success = true;
                }
                else
                {
                    result.ErrorMessage = response.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public override async Task<Response<QuizFormattedData>> GetAll()
        {
            var result = new Response<QuizFormattedData>();
            try
            {
                var quizzes = await _testRepository.GetAll();

                if(quizzes != null)
                {
                    result.Data = quizzes.Data.Select(x => new QuizFormattedData
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
                    result.ErrorMessage = "There are no quizzes";
                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public override async Task<Response<Models.DataModels.Quiz>> GetById(int id)
        {
            var result = new Response<Models.DataModels.Quiz>();

            try
            {
                var response = await _testRepository.GetById(id);

                if (response.Success)
                {
                    result.Data = response.Data;
                    result.Success = true;
                }
                else
                {
                    result.ErrorMessage = response.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public override async Task<Response<QuizFormattedData>> Update(Models.DataModels.Quiz data)
        {
            var result = new Response<QuizFormattedData>();

            try
            {
                if (ValidateTestContent(data, out string errorMessage))
                {
                    var response = await _testRepository.Update(data);

                    if (response.Success)
                    {
                        var updatedQuiz = response.Data.FirstOrDefault();

                        if (updatedQuiz != null)
                        {
                            result.Success = true;
                        }
                        else
                        {
                            result.ErrorMessage = "Update operation return epmty data";
                        }

                    }
                    else
                    {
                        result.ErrorMessage = response.ErrorMessage;
                    }
                }
                else
                {
                    result.ErrorMessage = errorMessage;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        private bool ValidateTestContent(Models.DataModels.Quiz data, out string errorMessage)
        {
            bool result = false;
            errorMessage = string.Empty;

            foreach (var question in data.questions)
            {
                if (!question.answers.Any(x => x.value == question.correctAnswer))
                {
                    errorMessage = $"Question {data.questions.IndexOf(question) + 1} has no answer that match correct one";
                    return result;
                }

            }

            result = true;
            return result;
        }
    }
}
