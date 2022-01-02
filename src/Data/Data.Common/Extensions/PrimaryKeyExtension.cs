using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Common.Extensions
{
    public static class PrimaryKeyExtension
    {
        public static int GetKeyValue(this DbContext context,Type entity)
        {
            var keyName = context?.Model?.FindEntityType(entity)?.FindPrimaryKey()?.Properties
                .Select(x => x.Name).Single();

            return (int)entity.GetProperty(keyName).GetValue(entity, null);
        }
        
    }
}
