﻿using SereneApi.Abstractions.Configuration;
using SereneApi.Abstractions.Request;
using SereneApi.Abstractions.Response;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SereneApi.Request;

namespace SereneApi.Tests.Interfaces
{
    public interface IApiHandlerWrapper: IDisposable
    {
        IConnectionSettings Connection { get; }

        IApiResponse PerformRequest(Method method, Expression<Func<IRequest, IRequestCreated>> factory = null);

        IApiResponse<TResponse> PerformRequest<TResponse>(Method method, Expression<Func<IRequest, IRequestCreated>> factory = null);

        Task<IApiResponse> PerformRequestAsync(Method method, Expression<Func<IRequest, IRequestCreated>> factory = null);

        Task<IApiResponse<TResponse>> PerformRequestAsync<TResponse>(Method method, Expression<Func<IRequest, IRequestCreated>> factory = null);
    }
}
