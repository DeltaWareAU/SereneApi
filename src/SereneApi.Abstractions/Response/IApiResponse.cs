﻿using System;

namespace SereneApi.Abstractions.Response
{
    /// <summary>
    /// The response received from the API.
    /// </summary>
    public interface IApiResponse
    {
        /// <summary>
        /// The status received from the API.
        /// </summary>
        Status Status { get; }

        /// <summary>
        /// Specifies if the request was successful.
        /// </summary>
        bool WasSuccessful { get; }

        /// <summary>
        /// Specifies if the request encountered an exception.
        /// </summary>
        bool HasException { get; }

        /// <summary>
        /// The message received from the API or returned from the ApiHandler.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// The exception that was encountered whilst processing the request.
        /// </summary>
        Exception Exception { get; }
    }
}
