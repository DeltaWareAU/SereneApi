﻿using DeltaWare.Dependencies;
using SereneApi.Interfaces;
using System;
using System.Diagnostics;

namespace SereneApi.Types
{
    [DebuggerDisplay("Source: {Connection.BaseAddress.ToString()}")]
    public class ApiHandlerOptions: IApiHandlerOptions
    {
        #region Properties

        /// <inheritdoc cref="IApiHandlerOptions.Dependencies"/>
        public IDependencyProvider Dependencies { get; }

        /// <inheritdoc cref="IApiHandlerOptions.Connection"/>
        public IConnectionSettings Connection { get; set; }

        #endregion
        #region Conclassors

        public ApiHandlerOptions(IDependencyProvider dependencies, IConnectionSettings connection)
        {
            Dependencies = dependencies;
            Connection = connection;
        }

        #endregion
        #region IDisposable

        private volatile bool _disposed;

        internal bool IsDisposed()
        {
            return _disposed;
        }

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
                Dependencies.Dispose();
            }

            _disposed = true;
        }

        #endregion
    }
}
