using Microsoft.EntityFrameworkCore;
using Quiz.DB;
using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;

namespace Quiz.Logic.DataRepositories
{
    public class TestRepository : Repository<Test>
    {
        public TestRepository(QuizDbContext context) : base(context)
        {
        }

        public override async Task<Response<Test>> Add(Test data)
        {
            var result = new Response<Test>();
            try
            {
                await _context.Database.BeginTransactionAsync();

                if (data != null)
                {
                    if(!string.IsNullOrEmpty(data.name))
                    {
                        await _context.Tests.AddAsync(data);
                        await SaveAsync();

                        result.Success = true;
                        await _context.Database.CommitTransactionAsync();
                    }
                    else
                    {
                        result.ErrorMessage = "Test name is empty";
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

        public override async Task<Response<Test>> Delete(int id)
        {
            var result = new Response<Test>();
            try
            {
                await _context.Database.BeginTransactionAsync();

                if (id < 0)
                {
                    var itemToDelete = await _context.Tests.FindAsync(id);

                    if (itemToDelete != null)
                    {
                        _context.Tests.Remove(itemToDelete);
                        await SaveAsync();

                        result.Success = true;
                        await _context.Database.CommitTransactionAsync();
                    }
                    else
                    {
                        result.ErrorMessage = "Test is not found";
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

        public override async Task<Response<Test>> GetAll()
        {
            var result = new Response<Test>();
            try
            {
                var tests = await _context.Tests.ToListAsync();

                if (tests != null && tests.Any())
                {
                    result.Data = tests;
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            
            return result;
        }

        public override async Task<Response<Test>> Update(Test data)
        {
            var result = new Response<Test>();
            try
            {
                await _context.Database.BeginTransactionAsync();

                if (data != null)
                {
                    var itemToUpdate = await _context.Tests.FindAsync(data.id);

                    if (itemToUpdate != null)
                    {
                        if (!string.IsNullOrEmpty(data.name))
                        {
                            itemToUpdate.name = data.name;
                            await SaveAsync();

                            result.Success = true;
                            await _context.Database.CommitTransactionAsync();
                        }
                        else
                        {
                            result.ErrorMessage = "Test name is empty";
                        }
                    }
                    else
                    {
                        result.ErrorMessage = "Test is not found";
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
