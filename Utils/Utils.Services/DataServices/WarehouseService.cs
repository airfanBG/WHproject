using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Infrastructure.Interfaces.Models;
using Utils.Infrastructure.Interfaces.Services;

namespace Utils.Services.DataServices
{
    internal class WarehouseService<T> : IBasicWarehouseService<T>where T:class
    {
        public IDatabaseService DatabaseService { get; set; }

        public WarehouseService(IDatabaseService databaseService)
        {
            this.DatabaseService = databaseService;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.DatabaseService.Context.Set<T>().ToListAsync();
        }
       

    }
}
