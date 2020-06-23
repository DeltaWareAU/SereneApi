﻿using SereneApi.Interfaces;
using System;
using System.Net.Http;

namespace SereneApi.Factories
{
    public class OverrideClientFactory: IClientFactory, IDisposable
    {
        private readonly HttpClient _client;

        private readonly bool _disposeClient;

        public OverrideClientFactory(HttpClient client, bool disposedClient = true)
        {
            _client = client;
            _disposeClient = disposedClient;
        }

        public HttpClient BuildClient()
        {
            return _client;
        }

        #region IDisposable

        private volatile bool _disposed;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(_disposed)
            {
                return;
            }

            if(disposing)
            {
                if(_disposeClient)
                {
                    _client.Dispose();
                }
            }

            _disposed = true;
        }

        #endregion
    }
}
