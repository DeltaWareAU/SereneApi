﻿using SereneApi.Enums;
using SereneApi.Interfaces;
using System;

namespace SereneApi.Types
{
    public class Dependency<TDependency> : IDependency<TDependency>, IDisposable
    {
        public DependencyBinding Binding { get; }

        /// <inheritdoc cref="IDependency{TDependency}.Instance"/>
        public TDependency Instance { get; }

        public Type Type => typeof(TDependency);

        public Dependency(TDependency instance, DependencyBinding binding = DependencyBinding.Bound)
        {
            Instance = instance;
            Binding = binding;
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
            if (_disposed)
            {
                return;
            }

            if (disposing && Binding == DependencyBinding.Bound && Instance is IDisposable disposableImplementation)
            {
                disposableImplementation.Dispose();
            }

            _disposed = true;
        }

        #endregion
    }
}
