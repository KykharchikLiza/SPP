using System;
using System.Runtime.InteropServices;

namespace MPP_lab4
{
    public class OSHandle:IDisposable
    {
        [DllImport("Kernel32.dll")]
        //закрывает дескриптор открытого объекта
        private static extern bool CloseHandle(IntPtr handle);
        private IntPtr Handle { get; set; }
        
        private bool _disposed;

        public OSHandle(IntPtr handle)
        {
            Handle = handle;
        }
        // реализация интерфейса IDisposable
        public void Dispose()
        {
            if (!_disposed)
            {
                CloseHandle(Handle);
                Handle = IntPtr.Zero;
                _disposed = true;
            }
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }
        //деструктор
        ~OSHandle()
        {
            Dispose ();
        }
    }
}