﻿//using DeltaWare.Dependencies.Abstractions;
//using SereneApi.Abstractions.Response;
//using System;
//using System.Threading.Tasks;

//// ReSharper disable once CheckNamespace
//namespace SereneApi
//{
//    public static class ApiOptionsExtensions
//    {
//        /// <summary>
//        /// Adds an authentication API. Before a request is made it will be authenticated.
//        /// The extracted token will be re-used until it expires at which point the authentication API will retrieve a new one.
//        /// </summary>
//        /// <typeparam name="TApi">The API that will be making the authentication request.</typeparam>
//        /// <typeparam name="TDto">The DTO returned by the authentication API.</typeparam>
//        /// <param name="callApi">Perform the authentication request.</param>
//        /// <param name="extractToken">Extract the token information from the response.</param>
//        /// <exception cref="ArgumentNullException">Thrown when a null value is provided.</exception>
//        /// <exception cref="InvalidCastException">Thrown when extensions does not implement <see cref="ICoreOptions"/>.</exception>
//        public static IApiOptionsExtensions AddAuthenticator<TApi, TDto>(this IApiOptionsExtensions extensions, Func<TApi, Task<IApiResponse<TDto>>> callApi, Func<TDto, TokenAuthResult> extractToken) where TApi : class, IDisposable where TDto : class
//        {
//            if (extensions == null)
//            {
//                throw new ArgumentNullException(nameof(extensions));
//            }

//            if (callApi == null)
//            {
//                throw new ArgumentNullException(nameof(callApi));
//            }

//            if (extractToken == null)
//            {
//                throw new ArgumentNullException(nameof(extractToken));
//            }

//            if (!(extensions is ICoreOptions options))
//            {
//                throw new InvalidCastException($"Base type must inherit {nameof(ICoreOptions)}");
//            }

//            options.Dependencies.AddSingleton<IAuthorizer>(p => new TokenAuthorizer<TApi, TDto>(p, callApi, extractToken));

//            return extensions;
//        }
//    }
//}
