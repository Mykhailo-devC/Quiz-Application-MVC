using Microsoft.EntityFrameworkCore;
using Quiz.DB;
using Quiz.Logic.Interfaces;
using Quiz.Models.DataModels;
using Quiz.Models.ResponseModels;

namespace Quiz.Logic.DataRepositories
{
    public class Repository<T> : IRepository<T> where T : BaseDataModel
    {
        protected QuizDbContext _context;
        protected DbSet<T> _dbSet;
        public Repository(QuizDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<Response<T>> GetAll()
        {
            var result = new Response<T>();

            try
            {
                var items = await GetAllItems();

                if (items != null && items.Any())
                {
                    result.Data = items;
                    result.Success = true;
                }
                else
                {
                    result.ErrorMessage = "There are no items";
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        protected virtual async Task<T?> FindItem(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        protected virtual async Task<IList<T>> GetAllItems()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task<Response<T>> GetById(int id)
        {
            var result = new Response<T>();

            try
            {
                if (id > 0)
                {
                    var item = await FindItem(id);

                    if (item != null)
                    {
                        result.Data.Add(item);
                        result.Success = true;
                    }
                    else
                    {
                        result.ErrorMessage = "Item is not found";
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

            return result;
        }

        public virtual async Task<Response<T>> Add(T data)
        {
            var result = new Response<T>();
            try
            {
                await _context.Database.BeginTransactionAsync();

                var newItem = await _dbSet.AddAsync(data);
                await SaveAsync();

                result.Success = true;
                result.Data.Add(newItem.Entity);
                await _context.Database.CommitTransactionAsync();

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

        protected virtual async Task<T> UpdateItem(T item)
        {
            var updatedItem = _dbSet.Update(item);
            return updatedItem.Entity;
        }

        public virtual async Task<Response<T>> Update(T data)
        {
            var result = new Response<T>();
            try
            {
                await _context.Database.BeginTransactionAsync();

                if (data != null)
                {
                    
                    var updatedItem = await UpdateItem(data);
                    await SaveAsync();

                    result.Success = true;
                    result.Data.Add(updatedItem);
                    await _context.Database.CommitTransactionAsync();
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

        public virtual async Task<Response<T>> Delete(int id)
        {
            var result = new Response<T>();
            try
            {
                await _context.Database.BeginTransactionAsync();

                if (id > 0)
                {
                    var itemToDelete = await _dbSet.FindAsync(id);

                    if (itemToDelete != null)
                    {
                        _dbSet.Remove(itemToDelete);
                        await SaveAsync();

                        result.Success = true;
                        await _context.Database.CommitTransactionAsync();
                    }
                    else
                    {
                        result.ErrorMessage = "Item is not found";
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

        protected async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}