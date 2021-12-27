using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Utils.Infrastructure.Interfaces.Services;

[assembly: InternalsVisibleTo("Tests.Services")]
namespace Utils.Services.DataServices
{
    internal class ApplicationDbContext : IDatabaseService
    {

        private bool disposed = false;
        public bool IsDisposed
        {
            get
            {
                return this.disposed;
            }
        }
        public DbContext Context { get; set; }
        public ApplicationDbContext(DbContext dbContext)
        {
            Context = dbContext;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }

                disposed = true;
            }
        }
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        ~ApplicationDbContext()
        {
            Dispose(disposing: false);
        }
    }
}
