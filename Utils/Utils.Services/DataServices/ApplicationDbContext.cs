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
    public class ApplicationDbContext : IDatabaseService
    {

        private bool disposed = false;
        IDisposable _disposableResource = new MemoryStream();
        IAsyncDisposable _asyncDisposableResource = new MemoryStream();
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

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);

            Dispose(disposing: false);
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
            GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposableResource?.Dispose();
                (_asyncDisposableResource as IDisposable)?.Dispose();
                _disposableResource = null;
                _asyncDisposableResource = null;
            }
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (_asyncDisposableResource is not null)
            {
                await _asyncDisposableResource.DisposeAsync().ConfigureAwait(false);
            }

            if (_disposableResource is IAsyncDisposable disposable)
            {
                await disposable.DisposeAsync().ConfigureAwait(false);
            }
            else
            {
                _disposableResource?.Dispose();
            }

            _asyncDisposableResource = null;
            _disposableResource = null;
        }
        //        public void Dispose()
        //        {
        //            Dispose(disposing: true);
        //            GC.SuppressFinalize(this);
        //        }

        //        protected virtual void Dispose(bool disposing)
        //        {
        //            if (!this.disposed)
        //            {
        //                if (disposing)
        //                {
        //                    Context.Dispose();
        //                }

        //                disposed = true;
        //            }
        //        }
        //        [System.Runtime.InteropServices.DllImport("Kernel32")]
        //        private extern static Boolean CloseHandle(IntPtr handle);

        //        public async ValueTask DisposeAsync()
        //        {
        //            await DisposeAsyncCore();

        //            Dispose(disposing: false);
        //#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        //            GC.SuppressFinalize(this);
        //#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        //        }
        //        protected virtual async ValueTask DisposeAsyncCore()
        //        {
        //            Context?.DisposeAsync();
        //        }
        //        ~ApplicationDbContext()
        //        {
        //            Dispose(disposing: false);
        //        }
    }
}
