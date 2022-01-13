using Data.Infrastructure.Interfaces.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utils.Infrastructure.Interfaces.Models;

namespace Utils.Infrastructure.Interfaces.Services
{
    public interface IBasicWarehouseService<T> where T : BaseModel
    {
        public IDatabaseService DatabaseService { get; set; }
        public List<IVmodel> QuerySelector(Expression<Func<T, IVmodel>> selector,
                                          Expression<Func<T, bool>> predicate = null,
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                          bool disableTracking = true);
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        public Task<IQueryable<T>> GetAllAsync(Func<T, bool> func=null);
        public Task<T> GetByIdAsync(int id);
        public Task<int> Add(T entity);
        public Task<int> Update(T entity);
        public Task<int> DeleteByIdAsync(int id);
        
       
    }
}
