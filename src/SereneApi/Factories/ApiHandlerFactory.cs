﻿using SereneApi.Helpers;
using SereneApi.Interfaces;
using SereneApi.Types;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace SereneApi.Factories
{
    public class ApiHandlerFactory: IApiHandlerFactory, IDisposable
    {
        private readonly Dictionary<Type, Action<IApiHandlerOptionsBuilder>> _handlerOptions = new Dictionary<Type, Action<IApiHandlerOptionsBuilder>>();

        private readonly Dictionary<Type, IApiHandlerExtensions> _handlerExtensions = new Dictionary<Type, IApiHandlerExtensions>();

        private readonly Dictionary<Type, HttpClient> _clients = new Dictionary<Type, HttpClient>();

        /// <summary>
        /// Builds an Instance of the <see cref="ApiHandler"/>
        /// </summary>
        /// <typeparam name="TApiHandler"></typeparam>
        /// <returns></returns>
        public TApiHandler Build<TApiHandler>() where TApiHandler : ApiHandler
        {
            Type handlerType = typeof(TApiHandler);

            if(!_handlerOptions.TryGetValue(handlerType, out Action<IApiHandlerOptionsBuilder> optionsBuilderAction))
            {
                throw new ArgumentException($"{nameof(TApiHandler)} has not been registered.");
            }

            ApiHandlerExtensions extensions = (ApiHandlerExtensions)_handlerExtensions[handlerType];

            if(!_clients.TryGetValue(handlerType, out HttpClient client))
            {
                if(extensions.DependencyCollection.TryGetDependency(out HttpMessageHandler messageHandler))
                {
                    client = new HttpClient(messageHandler);
                }
                else
                {
                    client = new HttpClient();
                }

                _clients.Add(handlerType, client);
            }

            // Disable client disposal for this ApiHandler as this factory has ownership of the client.
            ApiHandlerOptionsBuilder options = new ApiHandlerOptionsBuilder((DependencyCollection)extensions.DependencyCollection.Clone(), client, false);

            optionsBuilderAction.Invoke(options);

            TApiHandler handler = (TApiHandler)Activator.CreateInstance(typeof(TApiHandler), options.BuildOptions());

            return handler;
        }

        /// <summary>
        /// Registers an <see cref="IApiHandlerOptionsBuilder"/> against the <see cref="ApiHandler"/> which will be used when built.
        /// </summary>
        /// <typeparam name="TApiHandler"></typeparam>
        /// <param name="optionsAction"></param>
        public IApiHandlerExtensions RegisterApiHandler<TApiHandler>(Action<IApiHandlerOptionsBuilder> optionsAction) where TApiHandler : ApiHandler
        {
            Type handlerType = typeof(TApiHandler);

            if(_handlerOptions.ContainsKey(handlerType))
            {
                throw new ArgumentException($"Cannot Register Multiple Instances of {nameof(TApiHandler)}");
            }

            _handlerOptions.Add(handlerType, optionsAction);

            ApiHandlerOptionsBuilder builder = new ApiHandlerOptionsBuilder();

            optionsAction.Invoke(builder);

            ApiHandlerExtensions extensions = new ApiHandlerExtensions();

            if(builder.DependencyCollection.TryGetDependency(out JsonSerializerOptions serializerOptions))
            {
                extensions.DependencyCollection.AddDependency(serializerOptions);
            }

            _handlerExtensions.Add(handlerType, extensions);

            return extensions;
        }

        public IApiHandlerExtensions ExtendApiHandler<TApiHandler>() where TApiHandler : ApiHandler
        {
            if(!_handlerExtensions.TryGetValue(typeof(TApiHandler), out IApiHandlerExtensions extensions))
            {
                throw new ArgumentException($"Could not find any registered extensions to {typeof(TApiHandler)}");
            }

            return extensions;
        }

        public void ExtendApiHandler<TApiHandler>(Action<IApiHandlerExtensions> extensionsAction) where TApiHandler : ApiHandler
        {
            ExceptionHelper.EnsureParameterIsNotNull(extensionsAction, nameof(extensionsAction));

            if(!_handlerExtensions.TryGetValue(typeof(TApiHandler), out IApiHandlerExtensions extensions))
            {
                throw new ArgumentException($"Could not find any registered extensions to {typeof(TApiHandler)}");
            }

            extensionsAction.Invoke(extensions);
        }

        #region IDisposable

        private volatile bool _disposed;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(_disposed)
            {
                return;
            }

            if(disposing)
            {
                foreach(HttpClient client in _clients.Values)
                {
                    client.Dispose();
                }
            }

            _disposed = true;
        }

        #endregion
    }
}
