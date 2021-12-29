using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Infrastructure.Interfaces.Models;

namespace Utils.Infrastructure.Interfaces.Services
{
    public interface IBasicWarehouseService<T> where T : BaseModel
    {
        public IDatabaseService DatabaseService { get;protected set; }
        public Task<List<T>> GetAllAsync(Func<T, bool> func=null);
        public Task<T> GetByIdAsync(int id);
        public Task<int> Add(T entity);
        public Task<int> Update(T entity);
        public Task<int> DeleteByIdAsync(int id);
        

    }
}
