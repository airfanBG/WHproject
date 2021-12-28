using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Common.Extensions;
using Utils.Infrastructure.Interfaces.Models;
using Utils.Infrastructure.Interfaces.Services;

namespace Utils.Services.DataServices
{
    internal class WarehouseService<T> : IBasicWarehouseService<T>where T:BaseModel
    {
        public IDatabaseService DatabaseService { get; set; }

        public WarehouseService(IDatabaseService databaseService)
        {
            this.DatabaseService = databaseService;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var res= await this.DatabaseService.Context.Set<T>().ToListAsync();
            return res;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            
            var entity= this.DatabaseService.Context.Set<T>().FirstOrDefault(x => CompareIds(id));
            return entity;
        }
        private bool CompareIds(int id)
        {
            var keyValue = DatabaseService.Context.GetKeyValue(typeof(T));           
            return keyValue == id;
        }
    }
}
