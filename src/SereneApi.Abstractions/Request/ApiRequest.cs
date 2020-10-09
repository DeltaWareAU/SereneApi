﻿using SereneApi.Abstractions.Request.Content;
using System;

namespace SereneApi.Abstractions.Request
{
    /// <inheritdoc cref="IApiRequest"/>
    public class ApiRequest: IApiRequest
    {
        /// <inheritdoc cref="IApiRequest.Identity"/>
        public Guid Identity { get; }

        /// <inheritdoc cref="IApiRequest.Endpoint"/>
        public Uri Endpoint { get; }

        /// <inheritdoc cref="IApiRequest.Method"/>
        public Method Method { get; }

        /// <inheritdoc cref="IApiRequest.Content"/>
        public IApiRequestContent Content { get; }

        private ApiRequest()
        {
        }

        /// <summary>
        /// Creates a new instance of a <see cref="ApiRequest"/>.
        /// </summary>
        /// <param name="method">The <see cref="Method"/> used when performing the request.</param>
        /// <param name="endpoint">The endpoint of the API. This is applied after the source.</param>
        /// <param name="content">The content contained in the body of the request.</param>
        /// <exception cref="ArgumentException">Thrown if an invalid method is provided.</exception>
        public ApiRequest(Method method, Uri endpoint = null, IApiRequestContent content = null)
        {
            if(method == Method.NONE)
            {
                throw new ArgumentException("An invalid method was provided.");
            }

            Identity = Guid.NewGuid();

            Method = method;
            Endpoint = endpoint;
            Content = content;
        }

        /// <summary>
        /// An empty API request.
        /// </summary>
        /// <remarks>Mostly used internally for Unit Testing.</remarks>
        public static IApiRequest Empty { get; } = new ApiRequest();
    }

}
