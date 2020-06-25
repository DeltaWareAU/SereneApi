﻿using SereneApi.Abstraction.Enums;
using SereneApi.Extensions.Mocking.Enums;
using SereneApi.Extensions.Mocking.Interfaces;
using SereneApi.Extensions.Mocking.Types.Dependencies;
using SereneApi.Interfaces;
using SereneApi.Interfaces.Requests;
using SereneApi.Types;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SereneApi.Extensions.Mocking.Types
{
    /// <inheritdoc cref="IMockResponse"/>
    public class MockResponse: CoreOptions, IMockResponse, IDisposable
    {
        private readonly IApiRequestContent _responseContent;

        /// <inheritdoc cref="IMockResponse.Status"/>
        public Status Status { get; }

        /// <inheritdoc cref="IMockResponse.Message"/>
        public string Message { get; }

        /// <inheritdoc cref="IMockResponse.Serializer"/>
        public ISerializer Serializer { get; }

        public MockResponse(Status status, string message, IApiRequestContent responseContent, ISerializer serializer)
        {
            _responseContent = responseContent;

            Message = message;
            Status = status;
            Serializer = serializer;

            Dependencies.AddDependency(serializer);
        }

        /// <inheritdoc cref="IWhitelist.Validate"/>
        public Validity Validate(object value)
        {
            List<IWhitelist> whitelistDependencies = Dependencies.GetDependencies<IWhitelist>();

            // If 0 or any whitelist items return true. True is returned.

            foreach(IWhitelist whitelistDependency in whitelistDependencies)
            {
                Validity validity = whitelistDependency.Validate(value);

                if(validity == Validity.NotApplicable)
                {
                    continue;
                }

                return validity;
            }

            return Validity.NotApplicable;
        }

        /// <inheritdoc cref="IMockResponse"/>
        public async Task<IApiRequestContent> GetResponseContentAsync(CancellationToken cancellationToken = default)
        {
            if(Dependencies.TryGetDependency(out DelayedResponseDependency delay))
            {
                await delay.DelayAsync(cancellationToken);
            }

            return _responseContent;
        }

        /// <summary>
        /// Returns the <see cref="IMockResponseExtensions"/> for this <see cref="IMockResponse"/>.
        /// </summary>
        /// <remarks>The <see cref="IMockResponseExtensions"/> are used to add functionality to the <see cref="IMockResponse"/>.</remarks>
        public IMockResponseExtensions GetExtensions()
        {
            return new MockResponseExtensions(Dependencies);
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
                Dependencies.Dispose();
            }

            _disposed = true;
        }

        #endregion
    }
}
