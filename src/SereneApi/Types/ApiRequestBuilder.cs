﻿using SereneApi.Interfaces;
using System;
using System.Globalization;
using System.Linq.Expressions;
using SereneApi.Helpers;

namespace SereneApi.Types
{
    public class ApiRequestBuilder : IApiRequestBuilder
    {
        #region Readonly Variables

        private readonly IRouteFactory _routeFactory;

        private readonly ISerializer _serializer;

        private readonly IQueryFactory _queryFactory;

        #endregion

        private string _endPoint;

        private object[] _endPointParameters;

        private string _query;

        private Method _method = Method.None;

        private IApiRequestContent _content;

        public void WithEndPoint(string endPoint)
        {
            if (!string.IsNullOrWhiteSpace(_endPoint))
            {
                ExceptionHelper.MethodCannotBeCalledTwice();
            }

            _endPoint = endPoint;
        }

        public void WithEndPoint(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(_endPoint))
            {
                ExceptionHelper.MethodCannotBeCalledTwice();
            }

            _endPoint = parameter.ToString();
        }

        public void WithEndPoint(string endpointTemplate, params object[] templateParameters)
        {
            if (!string.IsNullOrWhiteSpace(_endPoint))
            {
                ExceptionHelper.MethodCannotBeCalledTwice();
            }

            _endPoint = endpointTemplate;
            _endPointParameters = templateParameters;
        }

        public void UsingMethod(Method method)
        {
            if (_method != Method.None)
            {
                ExceptionHelper.MethodCannotBeCalledTwice();
            }

            if (method == Method.None)
            {
                throw new ArgumentException("Method.None is not valid.", nameof(method));
            }

            _method = method;
        }

        public void AddQuery<TQueryable>(TQueryable queryable)
        {
            if (!string.IsNullOrWhiteSpace(_query))
            {
                ExceptionHelper.MethodCannotBeCalledTwice();
            }

            _query = _queryFactory.Build(queryable);
        }

        public void AddQuery<TQueryable>(TQueryable queryable, Expression<Func<TQueryable, object>> queryExpression)
        {
            if (!string.IsNullOrWhiteSpace(_query))
            {
                ExceptionHelper.MethodCannotBeCalledTwice();
            }

            _query = _queryFactory.Build(queryable, queryExpression);
        }

        public void AddInBodyContent<TContent>(TContent content)
        {
            if (_content != null)
            {
                ExceptionHelper.MethodCannotBeCalledTwice();
            }

            _content = _serializer.Serialize(content);
        }

        public IApiRequest BuildRequest()
        {
            Uri route = _routeFactory.BuildRouteWithQuery()
        }
    }
}
