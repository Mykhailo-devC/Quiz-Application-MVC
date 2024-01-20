using Microsoft.EntityFrameworkCore;
using Quiz.DB;
using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Logic.DataRepositories
{
    public class QuestionRepository : Repository<Question>
    {
        public QuestionRepository(QuizDbContext context) : base(context)
        {
        }

        public override async Task<ReposiotryResponse<Question>> Add(Question data)
        {
            var result = new ReposiotryResponse<Question>();
            try
            {
                await _context.Database.BeginTransactionAsync();

                if (data != null)
                {
                    if(!string.IsNullOrEmpty(data.value) || !string.IsNullOrEmpty(data.correctAnswer))
                    {
                        await _context.Questions.AddAsync(data);
                        await SaveAsync();

                        result.Success = true;
                        await _context.Database.CommitTransactionAsync();
                    }
                    else
                    {
                        result.ErrorMessage = "Question has no value";
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

        public override async Task<ReposiotryResponse<Question>> Delete(int id)
        {
            var result = new ReposiotryResponse<Question>();
            try
            {
                await _context.Database.BeginTransactionAsync();

                if (id < 0)
                {
                    var itemToDelete = await _context.Questions.FindAsync(id);

                    if (itemToDelete != null)
                    {
                        _context.Questions.Remove(itemToDelete);
                        await SaveAsync();

                        result.Success = true;
                        await _context.Database.CommitTransactionAsync();
                    }
                    else
                    {
                        result.ErrorMessage = "Question is not found";
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

        public override async Task<ReposiotryResponse<Question>> GetAll()
        {
            var result = new ReposiotryResponse<Question>();
            try
            {
                var questions = await _context.Questions.ToListAsync();

                if (questions != null && questions.Any())
                {
                    result.Data = questions;
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            
            return result;
        }

        public override async Task<ReposiotryResponse<Question>> Update(Question data)
        {
            var result = new ReposiotryResponse<Question>();
            try
            {
                await _context.Database.BeginTransactionAsync();

                if (data != null)
                {
                    var itemToUpdate = await _context.Questions.FindAsync(data.id);

                    if (itemToUpdate != null)
                    {
                        if (!string.IsNullOrEmpty(data.value) || !string.IsNullOrEmpty(data.correctAnswer))
                        {
                            itemToUpdate.value = data.value;
                            itemToUpdate.correctAnswer = data.correctAnswer;
                            await SaveAsync();

                            result.Success = true;
                            await _context.Database.CommitTransactionAsync();
                        }
                        else
                        {
                            result.ErrorMessage = "Question has no value";
                        }
                    }
                    else
                    {
                        result.ErrorMessage = "Question is not found";
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
