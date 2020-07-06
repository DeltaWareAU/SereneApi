using SereneApi.Abstractions.Handler;
using SereneApi.Abstractions.Handler.Options;
using SereneApi.Abstractions.Requests;
using SereneApi.Abstractions.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SereneApi
{
    /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}"/>
    public abstract class CrudApiHandler<TResource, TIdentifier>: ApiHandler, ICrudApi<TResource, TIdentifier> where TResource : class where TIdentifier : struct
    {
        /// <summary>
        /// Instantiates a new Instance of the <see cref="CrudApiHandler{TResource,TIdentifier}"/>
        /// </summary>
        /// <param name="options"></param>
        protected CrudApiHandler(IOptions options) : base(options)
        {
        }

        /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}.GetAsync"/>
        public Task<IApiResponse<TResource>> GetAsync(TIdentifier identifier)
        {
            return PerformRequestAsync<TResource>(Method.GET, request => request
                .WithEndPoint(identifier));
        }

        /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}.GetAllAsync"/>
        public Task<IApiResponse<List<TResource>>> GetAllAsync()
        {
            return PerformRequestAsync<List<TResource>>(Method.GET);
        }

        /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}.CreateAsync"/>
        public Task<IApiResponse<TResource>> CreateAsync(TResource resource)
        {
            return PerformRequestAsync<TResource>(Method.POST, request => request
                .WithInBodyContent(resource));
        }

        /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}.DeleteAsync"/>
        public Task<IApiResponse> DeleteAsync(TIdentifier identifier)
        {
            return PerformRequestAsync(Method.DELETE, request => request
                .WithEndPoint(identifier));
        }

        /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}.ReplaceAsync"/>
        public Task<IApiResponse<TResource>> ReplaceAsync(TResource resource)
        {
            return PerformRequestAsync<TResource>(Method.PUT, request => request
                .WithInBodyContent(resource));
        }

        /// <inheritdoc cref="ICrudApi{TResource,TIdentifier}.UpdateAsync"/>
        public Task<IApiResponse<TResource>> UpdateAsync(TResource resource)
        {
            return PerformRequestAsync<TResource>(Method.PATCH, request => request
                .WithInBodyContent(resource));
        }
    }
}
