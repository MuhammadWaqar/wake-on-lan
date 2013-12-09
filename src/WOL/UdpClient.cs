#if SILVERLIGHT

using System;
using System.Net;
using System.Net.Sockets;


namespace System.Net.Sockets
{
    // Silverlight-Compability implementation of the .NET UdpClient
    // (SL does not have an UdpClient)

    internal class UdpClient : IDisposable
    {
        private Socket _socket;

        public UdpClient()
            : this(AddressFamily.InterNetwork)
        { }

        public UdpClient(AddressFamily addressFamily)
        {
            _socket = new Socket(addressFamily, SocketType.Dgram, ProtocolType.Udp);
        }

        public void Send(byte[] dgram, int bytes, IPEndPoint endPoint)
        {
            CheckDisposed();
            if (dgram == null)
                throw new ArgumentNullException("dgram");

            var asc = new SocketAsyncEventArgs();
            asc.SetBuffer(dgram, 0, dgram.Length);
            asc.UserToken = _socket;
            asc.RemoteEndPoint = endPoint;
            _socket.SendAsync(asc);
        }

        public void Close()
        {
            this.Dispose(true);
        }

        private bool _disposed;
        private void CheckDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(this.GetType().FullName);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                if (_socket != null)
                {
                    _socket.Shutdown(SocketShutdown.Both);
                    _socket.Close();
                    _socket = null;
                }
                GC.SuppressFinalize(this);
                _disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}

#endif