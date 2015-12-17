using System;

namespace IDisposePattern
{
    public class BaseDisposableClass : IDisposable
    {
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DisposeManagedResource();
                }

                DisposeUnmanagedResource();

                _disposed = true;
            }
        }

        protected virtual void DisposeManagedResource()
        {
        }

        protected virtual void DisposeUnmanagedResource()
        {
        }

        ~BaseDisposableClass()
        {
            Dispose(false);
        }
    }
}