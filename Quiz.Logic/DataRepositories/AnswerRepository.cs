using Microsoft.EntityFrameworkCore;
using Quiz.DB;
using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;

namespace Quiz.Logic.DataRepositories
{
    public class AnswerRepository : Repository<Answer>
    {
        public AnswerRepository(QuizDbContext context) : base(context)
        {
        }

        public override async Task<Response<Answer>> Add(Answer data)
        {
            var result = new Response<Answer>();
            try
            {
                await _context.Database.BeginTransactionAsync();

                if (data != null)
                {
                    if(!string.IsNullOrEmpty(data.value))
                    {
                        await _context.Answers.AddAsync(data);
                        await SaveAsync();

                        result.Success = true;
                        await _context.Database.CommitTransactionAsync();
                    }
                    else
                    {
                        result.ErrorMessage = "Answer is empty";
                    }
                }
                else
                {
                    result.ErrorMessage = "Data model equals null";
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            if(!result.Success)
            {
                await _context.Database.RollbackTransactionAsync();
            }

            return result;
        }

        public override async Task<Response<Answer>> Delete(int id)
        {
            var result = new Response<Answer>();
            try
            {
                await _context.Database.BeginTransactionAsync();

                if (id < 0)
                {
                    var itemToDelete = await _context.Answers.FindAsync(id);

                    if (itemToDelete != null)
                    {
                        _context.Answers.Remove(itemToDelete);
                        await SaveAsync();

                        result.Success = true;
                        await _context.Database.CommitTransactionAsync();
                    }
                    else
                    {
                        result.ErrorMessage = "Answer not found";
                    }
                }
                else
                {
                    result.ErrorMessage = "Invalid id";
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            if (!result.Success)
            {
                await _context.Database.RollbackTransactionAsync();
            }

            return result;
        }

        public override async Task<Response<Answer>> GetAll()
        {
            var result = new Response<Answer>();
            try
            {
                var answers = await _context.Answers.ToListAsync();

                if (answers != null && answers.Any())
                {
                    result.Data = answers;
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            
            return result;
        }

        public override async Task<Response<Answer>> Update(Answer data)
        {
            var result = new Response<Answer>();
            try
            {
                await _context.Database.BeginTransactionAsync();

                if (data != null)
                {
                    var itemToUpdate = await _context.Answers.FindAsync(data.id);

                    if (itemToUpdate != null)
                    {
                        if (!string.IsNullOrEmpty(data.value))
                        {
                            itemToUpdate.value = data.value;
                            await SaveAsync();

                            result.Success = true;
                            await _context.Database.CommitTransactionAsync();
                        }
                        else
                        {
                            result.ErrorMessage = "Answer is empty";
                        }   
                    }
                    else
                    {
                        result.ErrorMessage = "Answer not found";
                    }
                }
                else
                {
                    result.ErrorMessage = "Data model equals null";
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            if (!result.Success)
            {
                await _context.Database.RollbackTransactionAsync();
            }

            return result;
        }
    }

}
