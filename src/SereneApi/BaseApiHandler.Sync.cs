﻿using Microsoft.Extensions.Logging;
using SereneApi.Abstractions.Factories;
using SereneApi.Abstractions.Request;
using SereneApi.Abstractions.Response;
using SereneApi.Abstractions.Response.Content;
using SereneApi.Abstractions.Serialization;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SereneApi
{
    public abstract partial class BaseApiHandler
    {
        #region Perform Methods

        /// <summary>
        /// Performs an API Request Synchronously.
        /// </summary>
        /// <param name="method">The <see cref="Method"/> that will be used for the request.</param>
        /// <param name="factory">The <see cref="IRequest"/> that will be performed.</param>
        protected IApiResponse PerformRequest(Method method, Expression<Func<IRequest, IRequestCreated>> factory = null)
        {
            CheckIfDisposed();

            RequestBuilder requestBuilder = new RequestBuilder(Options, Connection.Resource);

            requestBuilder.UsingMethod(method);

            factory?.Compile().Invoke(requestBuilder);

            IApiRequest request = requestBuilder.GetRequest();

            return PerformRequest(request);
        }

        /// <summary>
        /// Performs an API Request Synchronously.
        /// </summary>
        /// <param name="method">The <see cref="Method"/> that will be used for the request.</param>
        /// <param name="factory">The <see cref="IRequest"/> that will be performed.</param>
        /// <typeparam name="TResponse">The <see cref="Type"/> to be deserialized from the body of the response.</typeparam>
        protected IApiResponse<TResponse> PerformRequest<TResponse>(Method method, Expression<Func<IRequest, IRequestCreated>> factory = null)
        {
            CheckIfDisposed();

            RequestBuilder requestBuilder = new RequestBuilder(Options, Connection.Resource);

            requestBuilder.UsingMethod(method);

            factory?.Compile().Invoke(requestBuilder);

            IApiRequest request = requestBuilder.GetRequest();

            return PerformRequest<TResponse>(request);
        }

        /// <summary>
        /// Performs an API Request Synchronously.
        /// </summary>
        /// <param name="request">The request to be performed.</param>
        /// <exception cref="ArgumentNullException">Thrown when a null value is provided.</exception>
        protected virtual IApiResponse PerformRequest([NotNull] IApiRequest request)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            HttpResponseMessage responseMessage = null;

            Uri endpoint = request.Endpoint;

            Method method = request.Method;

            try
            {
                if(request.Content == null)
                {
                    _logger?.LogTrace("Performing a {httpMethod} request against {RequestRoute}", method.ToString(), endpoint);

                    responseMessage = RetryRequest(async client =>
                    {
                        return method switch
                        {
                            Method.POST => await client.PostAsync(endpoint, null),
                            Method.GET => await client.GetAsync(endpoint),
                            Method.PUT => await client.PutAsync(endpoint, null),
                            Method.PATCH => await client.PatchAsync(endpoint, null),
                            Method.DELETE => await client.DeleteAsync(endpoint),
                            Method.NONE => throw new ArgumentException("None is not a valid method for a request."),
                            _ => throw new ArgumentOutOfRangeException(nameof(endpoint), method,
                                "An incorrect Method Value was supplied.")
                        };
                    }, endpoint);
                }
                else
                {
                    _logger?.LogTrace("Performing a {httpMethod} request with in body content against {RequestRoute}", method.ToString(), endpoint);

                    HttpContent content = (HttpContent)request.Content.GetContent();

                    responseMessage = RetryRequest(async client =>
                    {
                        return method switch
                        {
                            Method.POST => await client.PostAsync(endpoint, content),
                            Method.GET => throw new ArgumentException(
                                "Get cannot be used in conjunction with an InBody Request"),
                            Method.PUT => await client.PutAsync(endpoint, content),
                            Method.PATCH => await client.PatchAsync(endpoint, content),
                            Method.DELETE => throw new ArgumentException(
                                "Delete cannot be used in conjunction with an InBody Request"),
                            Method.NONE => throw new ArgumentException("None is not a valid method for a request."),
                            _ => throw new ArgumentOutOfRangeException(nameof(method), method,
                                "An incorrect Method Value was supplied.")
                        };
                    }, endpoint);
                }

                _logger?.LogTrace("The {httpMethod} request against {RequestRoute} completed successfully.", method.ToString(), endpoint);

                return ProcessResponse(responseMessage);
            }
            catch(ArgumentException exception)
            {
                if(method == Method.GET || method == Method.DELETE || method == Method.NONE)
                {
                    _logger?.LogWarning("An invalid method [{httpMethod}] was provided.", method.ToString());

                    // An incorrect Method value was supplied. So we want this exception to bubble up to the caller.
                    throw;
                }

                _logger?.LogError(exception,
                    "An Exception occurred whilst performing a HTTP {httpMethod} Request to {RequestRoute}",
                    method.ToString(), endpoint);

                return ApiResponse.Failure(Status.None,
                    $"An Exception occurred whilst performing a HTTP {method} Request",
                    exception);
            }
            catch(TimeoutException exception)
            {
                _logger?.LogWarning(exception, "The Request Timed Out; Retry limit reach");

                return ApiResponse.Failure(Status.None, "The Request Timed Out; Retry limit reached", exception);
            }
            catch(Exception exception)
            {
                _logger?.LogError(exception,
                    "An Exception occurred whilst performing a HTTP {httpMethod} Request to \"{RequestRoute}\"",
                    method.ToString(), endpoint);

                return ApiResponse.Failure(Status.None,
                    $"An Exception occurred whilst performing a HTTP {method} Request",
                    exception);
            }
            finally
            {
                if(responseMessage != null)
                {
                    _logger?.LogDebug("Disposing response for the HTTP {httpMethod} Request to {RequestRoute}", method.ToString(), endpoint);

                    responseMessage.Dispose();
                }
            }
        }

        /// <summary>
        /// Performs an API Request Synchronously.
        /// </summary>
        /// <typeparam name="TResponse">The <see cref="Type"/> to be deserialized from the body of the response.</typeparam>
        /// <param name="request">The request to be performed.</param>
        /// <exception cref="ArgumentNullException">Thrown when a null value is provided.</exception>
        protected virtual IApiResponse<TResponse> PerformRequest<TResponse>([NotNull] IApiRequest request)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            HttpResponseMessage responseMessage = null;

            Uri endpoint = request.Endpoint;

            Method method = request.Method;

            try
            {
                if(request.Content == null)
                {
                    _logger?.LogTrace("Performing a {httpMethod} request against {RequestRoute}", method.ToString(), endpoint);

                    responseMessage = RetryRequest(async client =>
                    {
                        return method switch
                        {
                            Method.POST => await client.PostAsync(endpoint, null),
                            Method.GET => await client.GetAsync(endpoint),
                            Method.PUT => await client.PutAsync(endpoint, null),
                            Method.PATCH => await client.PatchAsync(endpoint, null),
                            Method.DELETE => await client.DeleteAsync(endpoint),
                            Method.NONE => throw new ArgumentException("None is not a valid method for a request."),
                            _ => throw new ArgumentOutOfRangeException(nameof(endpoint), method,
                                "An incorrect Method Value was supplied.")
                        };
                    }, endpoint);
                }
                else
                {
                    _logger?.LogTrace("Performing a {httpMethod} request with in body content against {RequestRoute}", method.ToString(), endpoint);

                    HttpContent content = (HttpContent)request.Content.GetContent();

                    responseMessage = RetryRequest(async client =>
                    {
                        return method switch
                        {
                            Method.POST => await client.PostAsync(endpoint, content),
                            Method.GET => throw new ArgumentException(
                                "Get cannot be used in conjunction with an InBody Request"),
                            Method.PUT => await client.PutAsync(endpoint, content),
                            Method.PATCH => await client.PatchAsync(endpoint, content),
                            Method.DELETE => throw new ArgumentException(
                                "Delete cannot be used in conjunction with an InBody Request"),
                            Method.NONE => throw new ArgumentException("None is not a valid method for a request."),
                            _ => throw new ArgumentOutOfRangeException(nameof(method), method,
                                "An incorrect Method Value was supplied.")
                        };
                    }, endpoint);
                }

                _logger?.LogTrace("The {httpMethod} request against {RequestRoute} completed successfully.", method.ToString(), endpoint);

                return ProcessResponse<TResponse>(responseMessage);
            }
            catch(ArgumentException exception)
            {
                if(method == Method.GET || method == Method.DELETE || method == Method.NONE)
                {
                    _logger?.LogWarning("An invalid method [{httpMethod}] was provided.", method.ToString());

                    // An incorrect Method value was supplied. So we want this exception to bubble up to the caller.
                    throw;
                }

                _logger?.LogError(exception,
                    "An Exception occurred whilst performing a HTTP {httpMethod} Request to {RequestRoute}",
                    method.ToString(), endpoint);

                return ApiResponse<TResponse>.Failure(Status.None,
                    $"An Exception occurred whilst performing a HTTP {method} Request",
                    exception);
            }
            catch(TimeoutException exception)
            {
                _logger?.LogWarning(exception, "The Request Timed Out; Retry limit reach");

                return ApiResponse<TResponse>.Failure(Status.None, "The Request Timed Out; Retry limit reached", exception);
            }
            catch(Exception exception)
            {
                _logger?.LogError(exception,
                    "An Exception occurred whilst performing a HTTP {httpMethod} Request to \"{RequestRoute}\"",
                    method.ToString(), endpoint);

                return ApiResponse<TResponse>.Failure(Status.None,
                    $"An Exception occurred whilst performing a HTTP {method} Request",
                    exception);
            }
            finally
            {
                if(responseMessage != null)
                {
                    _logger?.LogDebug("Disposing response for the HTTP {httpMethod} Request to {RequestRoute}", method.ToString(), endpoint);

                    responseMessage.Dispose();
                }
            }
        }

        /// <summary>
        /// Retries the request to the specified retry count.
        /// </summary>
        /// <param name="requestAction">The request to be performed.</param>
        /// <param name="route">The route to be inserted into the log.</param>
        /// <returns></returns>
        private HttpResponseMessage RetryRequest(Func<HttpClient, Task<HttpResponseMessage>> requestAction, Uri route)
        {
            bool retryingRequest;
            int requestsAttempted = 0;

            do
            {
                try
                {
                    IClientFactory clientFactory = Options.RetrieveRequiredDependency<IClientFactory>();

                    using HttpClient client = clientFactory.BuildClientAsync().Result;

                    // Using Task.Result bubbles the exception up to the caller.
                    // This means the Try Catch inside of RetryRequest does not catch the TaskCanceledException.
                    // The Try Catch in this method IS REQUIRED for the retry to functionality to work.
                    // To get around this, Task.GetAwaiter().GetResult() is necessary.
                    HttpResponseMessage responseMessage = requestAction.Invoke(client).GetAwaiter().GetResult();

                    return responseMessage;
                }
                catch(TaskCanceledException canceledException)
                {
                    requestsAttempted++;

                    if(Connection.RetryAttempts == 0 || requestsAttempted == Connection.RetryAttempts)
                    {
                        _logger?.LogError(canceledException, "The Request to \"{RequestRoute}\" has Timed Out; Retry limit reached. Retired {count}", route, requestsAttempted);

                        retryingRequest = false;
                    }
                    else
                    {
                        _logger?.LogWarning("Request to \"{RequestRoute}\" has Timed out, retrying. Attempts Remaining {count}", route, Connection.RetryAttempts - requestsAttempted);

                        retryingRequest = true;
                    }
                }
            } while(retryingRequest);

            throw new TimeoutException($"The Request to \"{route}\" has Timed Out; Retry limit reached. Retired {requestsAttempted}");
        }

        #endregion
        #region Response Processing

        /// <summary>
        /// Processes the returned <see cref="HttpResponseMessage"/> deserializing the contained <see cref="TResponse"/>
        /// </summary>
        /// <typeparam name="TResponse">The type to be deserialized from the response</typeparam>
        /// <param name="responseMessage">The <see cref="HttpResponseMessage"/> to process</param>
        private IApiResponse<TResponse> ProcessResponse<TResponse>(HttpResponseMessage responseMessage)
        {
            if(responseMessage == null)
            {
                _logger?.LogWarning("Received an Empty Http Response");

                return ApiResponse<TResponse>.Failure(Status.None, "Received an Empty Http Response");
            }

            Status status = responseMessage.StatusCode.ToStatus();

            if(!responseMessage.IsSuccessStatusCode)
            {
                _logger?.LogWarning("Http Request was not successful, received:{statusCode} - {message}", responseMessage.StatusCode, responseMessage.ReasonPhrase);

                return ApiResponse<TResponse>.Failure(status, responseMessage.ReasonPhrase);
            }

            if(responseMessage.Content == null)
            {
                _logger.LogWarning("No content was received in the response.");

                return ApiResponse<TResponse>.Failure(status, "No content was received in the response.");
            }

            try
            {
                ISerializer serializer = Options.RetrieveRequiredDependency<ISerializer>();

                TResponse response = serializer.Deserialize<TResponse>(new HttpContentResponse(responseMessage.Content));

                return ApiResponse<TResponse>.Success(status, response);
            }
            catch(JsonException jsonException)
            {
                _logger?.LogError(jsonException, "Could not deserialize the returned value");

                return ApiResponse<TResponse>.Failure(status, "Could not deserialize returned value.", jsonException);
            }
            catch(Exception exception)
            {
                _logger?.LogError(exception, "An Exception occurred whilst processing the response.");

                return ApiResponse<TResponse>.Failure(status, "An Exception occurred whilst processing the response.", exception);
            }
        }

        #endregion
    }
}
