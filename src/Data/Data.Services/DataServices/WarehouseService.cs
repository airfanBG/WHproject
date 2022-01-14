using Data.Infrastructure.Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Utils.Common.Extensions;
using Utils.Infrastructure.Interfaces.Models;
using Utils.Infrastructure.Interfaces.Services;

namespace Utils.Services.DataServices
{
    public class WarehouseService<T> : IBasicWarehouseService<T>where T:BaseModel
    {
        public IDatabaseService DatabaseService { get; set; }

        public WarehouseService(IDatabaseService databaseService)
        {
            this.DatabaseService = databaseService;
        }
        public List<IVmodel> QuerySelector(Expression<Func<T, IVmodel>> selector,
                                          Expression<Func<T, bool>> predicate = null,
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                          bool disableTracking = true)
        {
            IQueryable<T> query = DatabaseService.Context.Set<T>();
          
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
           
            if (orderBy != null)
            {
                return orderBy(query).Select(selector).ToList();
            }
            else
            {
                return query.Select(selector).ToList();
            }
           
        }
        public  IQueryable<T> GetAll(Expression<Func<T, bool>> predicate=null, params Expression<Func<T, object>>[] includes)
        {
            var query = DatabaseService.Context.Set<T>().AsQueryable();
           
            foreach (var include in includes)
            {
                var memberExpression = include.Body as MemberExpression;

                if (memberExpression != null)
                    query = query.Include(memberExpression.Member.Name);
            }
            IQueryable<T> result =null;
            if (predicate!=null)
            {
               result= query.Where(predicate).AsNoTracking();
            }
            else
            {
                result = query.AsNoTracking();
            }
            

            return result;
        }
        public async Task<IQueryable<T>> GetAllAsync(Func<T,bool> func)
        {
            try
            {
                IQueryable<T> res=null;
                if (func==null)
                {
                   res = this.DatabaseService.Context.Set<T>().AsNoTracking().AsQueryable<T>();
                }
                else
                {
                    res = this.DatabaseService.Context.Set<T>().AsNoTracking().Where(func).AsQueryable<T>();
                }
                
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var entity = this.DatabaseService.Context.Set<T>().FirstOrDefault(x => CompareIds(id));
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<int> Add(T entity)
        {
            try
            {
                await this.DatabaseService.Context.Set<T>().AddAsync(entity);
                var res = await DatabaseService.Context.SaveChangesAsync();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> Update(T entity)
        {
            try
            {
                 this.DatabaseService.Context.Set<T>().Update(entity);
                var res = await DatabaseService.Context.SaveChangesAsync();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            try
            {
                var entity =await this.DatabaseService.Context.Set<T>().FirstOrDefaultAsync(x => CompareIds(id));
                this.DatabaseService.Context.Set<T>().Remove(entity);
                var res = await DatabaseService.Context.SaveChangesAsync();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool CompareIds(int id)
        {
            var keyValue = DatabaseService.Context.GetKeyValue(typeof(T));
            return keyValue == id;
        }
    }
}
