﻿using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http.Headers;

namespace SereneApi.Interfaces
{
    public interface IApiHandlerOptionsBuilder
    {
        /// <summary>
        /// The Source the <see cref="ApiHandler"/> will use to make API requests against.
        /// </summary>
        /// <param name="source">The source of the Server, EG: http://someservice.com:8080</param>
        /// <param name="resource">The API resource that the <see cref="ApiHandler"/> will interact with.</param>
        /// <param name="resourcePath">The Path preceding the Resource. By default this is set to "api/".</param>
        void UseSource(string source, string resource = null, string resourcePath = null);

        /// <summary>
        /// Sets the timeout to be used by the <see cref="ApiHandler"/> when making API requests. By default this value is set to 30 seconds.
        /// </summary>
        /// <param name="seconds">the time in seconds before the request will be timed out.</param>
        void SetTimeoutPeriod(int seconds);

        /// <summary>
        /// Sets the timeout to be used by the <see cref="ApiHandler"/> when making API requests. By default this value is set to 30 seconds.
        /// </summary>
        /// <param name="timeoutPeriod">The <see cref="TimeSpan"/> to be used as the timeout period by the <see cref="ApiHandler"/>.</param>
        void SetTimeoutPeriod(TimeSpan timeoutPeriod);

        /// <summary>
        /// Adds an <see cref="ILogger"/> to the <see cref="ApiHandler"/> allowing built in Logging.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to be used for Logging.</param>
        void AddLogger(ILogger logger);

        /// <summary>
        /// When set, upon a timeout the <see cref="ApiHandler"/> will re-attempt the request. By Default this is disabled.
        /// </summary>
        /// <param name="retryCount">How many times the <see cref="ApiHandler"/> will re-attempt the request.</param>
        void SetRetryOnTimeout(int retryCount);

        /// <summary>
        /// Overrides the default <see cref="HttpResponseHeaders"/> with the supplied <see cref="HttpResponseHeaders"/>.
        /// </summary>
        void UseHttpRequestHeaders(Action<HttpRequestHeaders> requestHeaderBuilder);

        /// <summary>
        /// Overrides the default <see cref="IQueryFactory"/> with the supplied <see cref="IQueryFactory"/>.
        /// </summary>
        void UseQueryFactory(IQueryFactory queryFactory);

        /// <summary>
        /// Overrides the default <see cref="ICredentials"/> used by the <see cref="ApiHandler"/>.
        /// </summary>
        /// <param name="credentials">The <see cref="ICredentials"/> to be used when making requests.</param>
        void UseCredentials(ICredentials credentials);
    }
}
