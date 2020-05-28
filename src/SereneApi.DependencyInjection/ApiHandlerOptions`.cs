﻿using SereneApi.Interfaces;
using SereneApi.Types;
using System;

namespace SereneApi.DependencyInjection
{
    /// <summary>
    /// The <see cref="ApiHandlerOptions{TApiHandler}"/> to be used by the <see cref="ApiHandler"/> when making API requests
    /// </summary>
    public class ApiHandlerOptions<TApiHandler> : ApiHandlerOptions where TApiHandler : ApiHandler
    {
        #region Public Properties

        /// <summary>
        /// The <see cref="Type"/> of <see cref="ApiHandler"/> these <see cref="Interfaces.IApiHandlerOptions"/> will be used for.
        /// </summary>
        public Type HandlerType => typeof(TApiHandler);

        #endregion

        public ApiHandlerOptions(IDependencyCollection dependencyCollection, Uri source) : base(dependencyCollection, source)
        {
        }
    }
}
