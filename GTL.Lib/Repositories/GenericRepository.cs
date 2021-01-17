using GTL.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Lib.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public T AddEntity<T>(T entity) where T : class
        {
            try
            {
                _context.Entry<T>(entity).State = EntityState.Added;
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> AddEntityAsync<T>(T entity) where T : class
        {
            try
            {
                _context.Entry<T>(entity).State = EntityState.Added;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T UpdateEntity<T>(T updateObj) where T : class
        {
            try
            {
                _context.Entry<T>(updateObj).State = EntityState.Modified;
                _context.SaveChanges();

                return updateObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> UpdateEntityAsync<T>(T updateObj) where T : class
        {
            try
            {
                _context.Entry<T>(updateObj).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return updateObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T AddOrUpdateEntity<T>(T obj) where T : class
        {
            try
            {
                Type type = obj.GetType();
                int id = (int)obj.GetType().GetProperty(_context.Model.FindEntityType(type).FindPrimaryKey().Properties.Select(x => x.Name).FirstOrDefault()).GetValue(obj);
                if (id == 0)
                {
                    return AddEntity(obj);
                }
                else
                {
                    return UpdateEntity(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteEntity<T>(T deleteObj) where T : class
        {
            try
            {
                _context.Entry<T>(deleteObj).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteEntityAsync<T>(T deleteObj) where T : class
        {
            try
            {
                _context.Entry<T>(deleteObj).State = EntityState.Deleted;
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetEntity<T>(object id) where T : class
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
