using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Lib.Repositories
{
    public interface IGenericRepository
    {
        T AddEntity<T>(T entity) where T : class;
        Task<T> AddEntityAsync<T>(T entity) where T : class;
        T AddOrUpdateEntity<T>(T obj) where T : class;
        void DeleteEntity<T>(T deleteObj) where T : class;
        Task<int> DeleteEntityAsync<T>(T deleteObj) where T : class;
        T GetEntity<T>(object id) where T : class;
        T UpdateEntity<T>(T updateObj) where T : class;
        Task<T> UpdateEntityAsync<T>(T updateObj) where T : class;
    }
}
