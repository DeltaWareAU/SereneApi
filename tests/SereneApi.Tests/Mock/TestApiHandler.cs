﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SereneApi.Interfaces;

namespace SereneApi.Tests.Mock
{
    public class TestApiHandler : ApiHandler
    {
        public TestApiHandler(IApiHandlerOptions options) : base(options)
        {
        }

        #region Sync Methods

        public new IApiResponse PerformRequest(Method method, Expression<Func<IRequest, IRequestCreated>> request = null)
        {
            return base.PerformRequest(method, request);
        }

        public new IApiResponse<TResponse> PerformRequest<TResponse>(Method method, Expression<Func<IRequest, IRequestCreated>> request = null)
        {
            return base.PerformRequest<TResponse>(method, request);
        }

        #endregion
        #region Async Methods

        public new Task<IApiResponse> PerformRequestAsync(Method method, Expression<Func<IRequest, IRequestCreated>> request = null)
        {
            return base.PerformRequestAsync(method, request);
        }

        public new Task<IApiResponse<TResponse>> PerformRequestAsync<TResponse>(Method method, Expression<Func<IRequest, IRequestCreated>> request = null)
        {
            return base.PerformRequestAsync<TResponse>(method, request);
        }
        
        #endregion
        #region Legacy

        public new Task<IApiResponse> InPathRequestAsync(Method method, object endpoint = null)
        {
            return base.InPathRequestAsync(method, endpoint);
        }

        public new Task<IApiResponse> InPathRequestAsync(Method method, string endpointTemplate, params object[] endpointParameters)
        {
            return base.InPathRequestAsync(method, endpointTemplate, endpointParameters);
        }

        public new Task<IApiResponse<TResponse>> InPathRequestAsync<TResponse>(Method method, object endpoint = null)
        {
            return base.InPathRequestAsync<TResponse>(method, endpoint);
        }

        public new Task<IApiResponse<TResponse>> InPathRequestAsync<TResponse>(Method method, string endpointTemplate, params object[] endpointParameters)
        {
            return base.InPathRequestAsync<TResponse>(method, endpointTemplate, endpointParameters);
        }

        public new Task<IApiResponse<TResponse>> InPathRequestWithQueryAsync<TResponse, TQuery>(Method method, TQuery queryContent, Expression<Func<TQuery, object>> query, object endpoint = null) where TQuery : class
        {
            return base.InPathRequestWithQueryAsync<TResponse, TQuery>(method, queryContent, query, endpoint);
        }

        public new Task<IApiResponse<TResponse>> InPathRequestWithQueryAsync<TResponse, TQuery>(Method method, TQuery queryContent, Expression<Func<TQuery, object>> query, string endpointTemplate, params object[] endpointParameters) where TQuery : class
        {
            return base.InPathRequestWithQueryAsync<TResponse, TQuery>(method, queryContent, query, endpointTemplate, endpointParameters);
        }

        public new Task<IApiResponse> InBodyRequestAsync<TContent>(Method method, TContent inBodyContent, object endpoint = null)
        {
            return base.InBodyRequestAsync<TContent>(method, inBodyContent, endpoint);
        }

        public new Task<IApiResponse> InBodyRequestAsync<TContent>(Method method, TContent inBodyContent, string endpointTemplate, params object[] endpointParameters)
        {
            return base.InBodyRequestAsync<TContent>(method, inBodyContent, endpointTemplate, endpointParameters);
        }

        public new Task<IApiResponse<TResponse>> InBodyRequestAsync<TContent, TResponse>(Method method, TContent inBodyContent, object endpoint = null)
        {
            return base.InBodyRequestAsync<TContent, TResponse>(method, inBodyContent, endpoint);
        }

        public new Task<IApiResponse<TResponse>> InBodyRequestAsync<TContent, TResponse>(Method method, TContent inBodyContent, string endpointTemplate, params object[] endpointParameters)
        {
            return base.InBodyRequestAsync<TContent, TResponse>(method, inBodyContent, endpointTemplate, endpointParameters);
        }
        
        #endregion
    }
}
