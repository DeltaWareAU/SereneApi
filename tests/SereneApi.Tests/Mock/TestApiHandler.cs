﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SereneApi.Tests.Mock
{
    public class TestApiHandler : ApiHandler
    {
        public TestApiHandler(IApiHandlerOptions options) : base(options)
        {
        }

        public async Task<IApiResponse> Test()
        {
            return await PerformRequestAsync(builder =>
            {
                builder.UsingMethod(Method.Post);
                builder.AddQuery(MockPersonDto.John, dto => new {dto.Age});
                builder.AddInBodyContent(MockPersonDto.John);
                builder.WithEndPoint("{0}/Details", MockPersonDto.John.Name);
            });
        }
        
        public async Task<IApiResponse<TResponse>> Test<TResponse>()
        {
            return await PerformRequestAsync<TResponse>(builder =>
            {
                builder.UsingMethod(Method.Post);
                builder.AddInBodyContent(MockPersonDto.John);
                builder.WithEndPoint("");
            });
        }

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
    }
}
