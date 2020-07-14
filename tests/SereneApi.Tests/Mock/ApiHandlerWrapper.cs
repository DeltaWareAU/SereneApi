﻿using SereneApi.Abstractions.Options;
using SereneApi.Abstractions.Request;
using SereneApi.Abstractions.Response;
using SereneApi.Tests.Interfaces;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SereneApi.Tests.Mock
{
    public class ApiHandlerWrapper: ApiHandler, IApiHandlerWrapper
    {
        public ApiHandlerWrapper(IApiOptions options) : base(options)
        {
        }

        #region Sync Methods

        public new IApiResponse PerformRequest(Method method, Expression<Func<IRequest, IRequestCreated>> factory = null)
        {
            return base.PerformRequest(method, factory);
        }

        public new IApiResponse<TResponse> PerformRequest<TResponse>(Method method, Expression<Func<IRequest, IRequestCreated>> factory = null)
        {
            return base.PerformRequest<TResponse>(method, factory);
        }

        #endregion
        #region Async Methods

        public new Task<IApiResponse> PerformRequestAsync(Method method, Expression<Func<IRequest, IRequestCreated>> factory = null)
        {
            return base.PerformRequestAsync(method, factory);
        }

        public new Task<IApiResponse<TResponse>> PerformRequestAsync<TResponse>(Method method, Expression<Func<IRequest, IRequestCreated>> factory = null)
        {
            return base.PerformRequestAsync<TResponse>(method, factory);
        }

        #endregion
    }
}
