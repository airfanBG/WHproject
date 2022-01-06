using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common.Extensions
{
    public static class DatabaseExtensions
    {
        public static IQueryable<T> CustomQuery<T>(this DbContext context) where T : class
        {
            return context.Set<T>().AsQueryable();
        }
    }
}
