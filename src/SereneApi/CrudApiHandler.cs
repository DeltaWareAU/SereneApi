﻿using DeltaWare.SereneApi.Enums;
using DeltaWare.SereneApi.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeltaWare.SereneApi
{
    /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}"/>
    public abstract class CrudApiHandler<TResource, TIdentifier> : ApiHandler, ICrudApi<TResource, TIdentifier> where TResource : class where TIdentifier : struct
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Instantiates a new Instance of the <see cref="CrudApiHandler{TResource,TIdentifier}"/>.
        /// </summary>
        /// <param name="options"></param>
        protected CrudApiHandler(IApiHandlerOptions options) : base(options)
        {
            _logger = options.Logger;
        }

        /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}.GetAsync"/>
        public Task<IApiResponse<TResource>> GetAsync(TIdentifier identity)
        {
            return InPathRequestAsync<TResource>(ApiMethod.Get, identity);
        }

        /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}.GetAllAsync"/>
        public Task<IApiResponse<IList<TResource>>> GetAllAsync()
        {
            return InPathRequestAsync<IList<TResource>>(ApiMethod.Get);
        }

        /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}.CreateAsync"/>
        public Task<IApiResponse<TResource>> CreateAsync(TResource resource)
        {
            return InBodyRequestAsync<TResource, TResource>(ApiMethod.Post, resource);
        }

        /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}.DeleteAsync"/>
        public Task<IApiResponse> DeleteAsync(TIdentifier identifier)
        {
            return InPathRequestAsync(ApiMethod.Delete, identifier);
        }

        /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}.ReplaceAsync"/>
        public Task<IApiResponse<TResource>> ReplaceAsync(TResource resource)
        {
            return InBodyRequestAsync<TResource, TResource>(ApiMethod.Put, resource);
        }

        /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}.UpdateAsync"/>
        public Task<IApiResponse<TResource>> UpdateAsync(TResource resource)
        {
            return InBodyRequestAsync<TResource, TResource>(ApiMethod.Patch, resource);
        }
    }
}
