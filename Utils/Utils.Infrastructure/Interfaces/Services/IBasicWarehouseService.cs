﻿using System;
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
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
    }
}
