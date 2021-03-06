﻿using SereneApi.Abstractions.Serialization;
using System;

namespace SereneApi.Abstractions.Requests.Builder
{
    public interface IApiRequestType : IApiRequestResponseType
    {
        /// <summary>
        /// Specifies the content be sent in the request.
        /// </summary>
        /// <param name="content">The content to be serialized into JSON data.</param>
        /// <exception cref="ArgumentNullException">Thrown when a null value is provided.</exception>
        /// <remarks>Content is serialized using the <see cref="ISerializer"/>.</remarks>
        IApiRequestResponseType AddInBodyContent<TContent>(TContent content);
    }
}
