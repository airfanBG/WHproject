using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("Tests.Services")]
namespace Utils.Infrastructure.Interfaces.Services
{
    public interface IDatabaseService:IDisposable
    {
        public DbContext Context { get; set; }
    }
}
