﻿using System;

namespace SereneApi.Interfaces.Requests
{
    public interface IRequest: IRequestEndPoint
    {
        /// <summary>
        /// If no resource was provided in the <see cref="IApiHandlerOptions"/> to the <see cref="ApiHandler"/> it can be provided here.
        /// </summary>
        /// <param name="resource">The resource to make the request against.</param>
        /// <exception cref="MethodAccessException">Thrown if this method is called when a resource was provided in the <see cref="IApiHandlerOptions"/>.</exception>
        IRequestEndPoint AgainstResource(string resource);
    }
}
