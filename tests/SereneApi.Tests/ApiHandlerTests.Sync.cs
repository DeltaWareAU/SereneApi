﻿using SereneApi.Abstraction.Enums;
using SereneApi.Extensions.Mocking;
using SereneApi.Factories;
using SereneApi.Helpers;
using SereneApi.Tests.Mock;
using Shouldly;
using System;
using Xunit;

namespace SereneApi.Tests
{
    public class ApiHandlerTestsSync
    {
        #region Exceptions

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void ExceptionGetRequestAgainstResourceWhenResourceAssigned(string source, string resource)
        {
            #region Arrange


            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            #endregion
            #region Assert

            Should.Throw<MemberAccessException>(() =>
            {
                apiHandler.PerformRequest(Method.Get, r => r.AgainstResource(resource));
            });

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void ExceptionGetRequestAgainstResourceWhenResourceAssignedGeneric(string source, string resource)
        {
            #region Arrange

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());
            
            #endregion
            #region Assert

            Should.Throw<MemberAccessException>(() =>
            {
                apiHandler.PerformRequest<MockPersonDto>(Method.Get, r => r.AgainstResource(resource));
            });

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void ExceptionDeleteRequestAgainstResourceWhenResourceAssigned(string source, string resource)
        {
            #region Arrange


            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            #endregion
            #region Assert

            Should.Throw<MemberAccessException>(() =>
            {
                apiHandler.PerformRequest(Method.Delete, r => r.AgainstResource(resource));
            });

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void ExceptionDeleteRequestAgainstResourceWhenResourceAssignedGeneric(string source, string resource)
        {
            #region Arrange

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            #endregion
            #region Assert

            Should.Throw<MemberAccessException>(() =>
            {
                apiHandler.PerformRequest<MockPersonDto>(Method.Delete, r => r.AgainstResource(resource));
            });

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void ExceptionPostRequestAgainstResourceWhenResourceAssigned(string source, string resource)
        {
            #region Arrange


            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            #endregion
            #region Assert

            Should.Throw<MemberAccessException>(() =>
            {
                apiHandler.PerformRequest(Method.Post, r => r.AgainstResource(resource));
            });

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void ExceptionPostRequestAgainstResourceWhenResourceAssignedGeneric(string source, string resource)
        {
            #region Arrange

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            #endregion
            #region Assert

            Should.Throw<MemberAccessException>(() =>
            {
                apiHandler.PerformRequest<MockPersonDto>(Method.Post, r => r.AgainstResource(resource));
            });

            #endregion
        }


        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void ExceptionPutRequestAgainstResourceWhenResourceAssigned(string source, string resource)
        {
            #region Arrange


            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            #endregion
            #region Assert

            Should.Throw<MemberAccessException>(() =>
            {
                apiHandler.PerformRequest(Method.Put, r => r.AgainstResource(resource));
            });

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void ExceptionPutRequestAgainstResourceWhenResourceAssignedGeneric(string source, string resource)
        {
            #region Arrange

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            #endregion
            #region Assert

            Should.Throw<MemberAccessException>(() =>
            {
                apiHandler.PerformRequest<MockPersonDto>(Method.Put, r => r.AgainstResource(resource));
            });

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void ExceptionPatchRequestAgainstResourceWhenResourceAssigned(string source, string resource)
        {
            #region Arrange


            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            #endregion
            #region Assert

            Should.Throw<MemberAccessException>(() =>
            {
                apiHandler.PerformRequest(Method.Patch, r => r.AgainstResource(resource));
            });

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void ExceptionPatchRequestAgainstResourceWhenResourceAssignedGeneric(string source, string resource)
        {
            #region Arrange

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            #endregion
            #region Assert

            Should.Throw<MemberAccessException>(() =>
            {
                apiHandler.PerformRequest<MockPersonDto>(Method.Patch, r => r.AgainstResource(resource));
            });

            #endregion
        }

        #endregion


        #region Basic Get Tests

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com", "path/resource")]
        [InlineData("http://test.source.com", "path/path/resource")]
        [InlineData("http://test.source.com:80", "test/resource")]
        [InlineData("http://test.source.com:443", "path/resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void SuccessfulBasicGetRequest(string source, string resource)
        {
            #region Arrange

            string finalSource = $"{source}/api/{resource}";

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            handlerFactory.ExtendApiHandler<ApiHandlerWrapper>().WithMockResponses(r =>
            {
                r.AddMockResponse(Status.Ok)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith(finalSource);
            });

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            IApiResponse response = Should.NotThrow(() => apiHandler.PerformRequest(Method.Get));

            #endregion
            #region Assert

            apiHandler.Resource.ShouldBe(resource);
            apiHandler.Source.ShouldBe(new Uri(finalSource));
            apiHandler.ResourcePath.ShouldBe(ApiHandlerOptionDefaults.ResourcePath);
            apiHandler.RetryCount.ShouldBe(ApiHandlerOptionDefaults.RetryCount);
            apiHandler.Timeout.ShouldBe(ApiHandlerOptionDefaults.TimeoutPeriod);

            response.WasSuccessful.ShouldBe(true);
            response.HasException.ShouldBe(false);
            response.Message.ShouldBeNull();
            response.Exception.ShouldBeNull();
            response.Status.ShouldBe(Status.Ok);

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com", "path/resource")]
        [InlineData("http://test.source.com", "path/path/resource")]
        [InlineData("http://test.source.com:80", "test/resource")]
        [InlineData("http://test.source.com:443", "path/resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void SuccessfulBasicGetRequestGeneric(string source, string resource)
        {
            #region Arrange

            string finalSource = $"{source}/api/{resource}";

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            handlerFactory.ExtendApiHandler<ApiHandlerWrapper>().WithMockResponses(r =>
            {
                r.AddMockResponse(MockPersonDto.JohnSmith)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith(finalSource);
            });

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            IApiResponse<MockPersonDto> response = Should.NotThrow(() => apiHandler.PerformRequest<MockPersonDto>(Method.Get));

            #endregion
            #region Assert

            apiHandler.Resource.ShouldBe(resource);
            apiHandler.Source.ShouldBe(new Uri(finalSource));
            apiHandler.ResourcePath.ShouldBe(ApiHandlerOptionDefaults.ResourcePath);
            apiHandler.RetryCount.ShouldBe(ApiHandlerOptionDefaults.RetryCount);
            apiHandler.Timeout.ShouldBe(ApiHandlerOptionDefaults.TimeoutPeriod);

            response.WasSuccessful.ShouldBe(true);
            response.HasException.ShouldBe(false);
            response.Message.ShouldBeNull();
            response.Exception.ShouldBeNull();
            response.Status.ShouldBe(Status.Ok);

            MockPersonDto person = response.Result;

            person.Age.ShouldBe(MockPersonDto.JohnSmith.Age);
            person.BirthDate.ShouldBe(MockPersonDto.JohnSmith.BirthDate);
            person.Name.ShouldBe(MockPersonDto.JohnSmith.Name);

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource", 2, 2)]
        [InlineData("http://test.source.com:8080", "path/path/resource", 3, 2)]
        public void SuccessfulBasicGetRequestWithTimeout(string source, string resource, int retryCount, int timeoutSeconds)
        {
            #region Arrange

            string finalSource = $"{source}/api/{resource}";

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(o =>
            {
                o.UseSource(source, resource);
                o.SetTimeoutPeriod(timeoutSeconds);
                o.SetRetryOnTimeout(retryCount);
            });

            handlerFactory.ExtendApiHandler<ApiHandlerWrapper>().WithMockResponses(r =>
            {
                r.AddMockResponse(Status.Ok)
                    .ResponseIsDelayed(timeoutSeconds + 2, retryCount - 1)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith(finalSource);
            });

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            IApiResponse response = Should.NotThrow(() => apiHandler.PerformRequest(Method.Get));

            #endregion
            #region Assert

            apiHandler.Resource.ShouldBe(resource);
            apiHandler.Source.ShouldBe(new Uri(finalSource));
            apiHandler.ResourcePath.ShouldBe(ApiHandlerOptionDefaults.ResourcePath);
            apiHandler.RetryCount.ShouldBe(retryCount);
            apiHandler.Timeout.ShouldBe(TimeSpan.FromSeconds(timeoutSeconds));

            response.WasSuccessful.ShouldBe(true);
            response.HasException.ShouldBe(false);
            response.Message.ShouldBeNull();
            response.Exception.ShouldBeNull();
            response.Status.ShouldBe(Status.Ok);

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource", 2, 2)]
        [InlineData("http://test.source.com:8080", "path/path/resource", 3, 2)]
        public void SuccessfulBasicGetRequestWithTimeoutGeneric(string source, string resource, int retryCount, int timeoutSeconds)
        {
            #region Arrange

            string finalSource = $"{source}/api/{resource}";

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(o =>
            {
                o.UseSource(source, resource);
                o.SetTimeoutPeriod(timeoutSeconds);
                o.SetRetryOnTimeout(retryCount);
            });

            handlerFactory.ExtendApiHandler<ApiHandlerWrapper>().WithMockResponses(r =>
            {
                r.AddMockResponse(MockPersonDto.JohnSmith)
                    .ResponseIsDelayed(timeoutSeconds + 2, retryCount - 1)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith(finalSource);
            });

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            IApiResponse<MockPersonDto> response = Should.NotThrow(() => apiHandler.PerformRequest<MockPersonDto>(Method.Get));

            #endregion
            #region Assert

            apiHandler.Resource.ShouldBe(resource);
            apiHandler.Source.ShouldBe(new Uri(finalSource));
            apiHandler.ResourcePath.ShouldBe(ApiHandlerOptionDefaults.ResourcePath);
            apiHandler.RetryCount.ShouldBe(retryCount);
            apiHandler.Timeout.ShouldBe(TimeSpan.FromSeconds(timeoutSeconds));

            response.WasSuccessful.ShouldBe(true);
            response.HasException.ShouldBe(false);
            response.Message.ShouldBeNull();
            response.Exception.ShouldBeNull();
            response.Status.ShouldBe(Status.Ok);

            MockPersonDto person = response.Result;

            person.Age.ShouldBe(MockPersonDto.JohnSmith.Age);
            person.BirthDate.ShouldBe(MockPersonDto.JohnSmith.BirthDate);
            person.Name.ShouldBe(MockPersonDto.JohnSmith.Name);

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com", "path/resource")]
        [InlineData("http://test.source.com", "path/path/resource")]
        [InlineData("http://test.source.com:80", "test/resource")]
        [InlineData("http://test.source.com:443", "path/resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void UnSuccessfulBasicGetRequest(string source, string resource)
        {
            #region Arrange

            const string message = "Exception occured whilst getting.";
            const Status status = Status.InternalServerError;

            string finalSource = $"{source}/api/{resource}";

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            handlerFactory.ExtendApiHandler<ApiHandlerWrapper>().WithMockResponses(r =>
            {
                r.AddMockResponse(status, message)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith(finalSource);
            });

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            IApiResponse response = Should.NotThrow(() => apiHandler.PerformRequest(Method.Get));

            #endregion
            #region Assert

            apiHandler.Resource.ShouldBe(resource);
            apiHandler.Source.ShouldBe(new Uri(finalSource));
            apiHandler.ResourcePath.ShouldBe(ApiHandlerOptionDefaults.ResourcePath);
            apiHandler.RetryCount.ShouldBe(ApiHandlerOptionDefaults.RetryCount);
            apiHandler.Timeout.ShouldBe(ApiHandlerOptionDefaults.TimeoutPeriod);

            response.WasSuccessful.ShouldBe(false);
            response.HasException.ShouldBe(false);
            response.Message.ShouldBe(message);
            response.Exception.ShouldBeNull();
            response.Status.ShouldBe(status);

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com", "path/resource")]
        [InlineData("http://test.source.com", "path/path/resource")]
        [InlineData("http://test.source.com:80", "test/resource")]
        [InlineData("http://test.source.com:443", "path/resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void UnSuccessfulBasicGetRequestGeneric(string source, string resource)
        {
            #region Arrange

            const string message = "Exception occured whilst getting.";
            const Status status = Status.InternalServerError;

            string finalSource = $"{source}/api/{resource}";

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source, resource));

            handlerFactory.ExtendApiHandler<ApiHandlerWrapper>().WithMockResponses(r =>
            {
                r.AddMockResponse(status, message)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith(finalSource);
            });

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            IApiResponse<MockPersonDto> response = Should.NotThrow(() => apiHandler.PerformRequest<MockPersonDto>(Method.Get));

            #endregion
            #region Assert

            apiHandler.Resource.ShouldBe(resource);
            apiHandler.Source.ShouldBe(new Uri(finalSource));
            apiHandler.ResourcePath.ShouldBe(ApiHandlerOptionDefaults.ResourcePath);
            apiHandler.RetryCount.ShouldBe(ApiHandlerOptionDefaults.RetryCount);
            apiHandler.Timeout.ShouldBe(ApiHandlerOptionDefaults.TimeoutPeriod);

            response.WasSuccessful.ShouldBe(false);
            response.HasException.ShouldBe(false);
            response.Message.ShouldBe(message);
            response.Exception.ShouldBeNull();
            response.Status.ShouldBe(status);
            response.Result.ShouldBeNull();

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource", 2, 2)]
        [InlineData("http://test.source.com:8080", "path/path/resource", 3, 2)]
        public void UnSuccessfulBasicGetRequestWithTimeout(string source, string resource, int retryCount, int timeoutSeconds)
        {
            #region Arrange

            const string message = "Exception occured whilst getting.";
            const Status status = Status.InternalServerError;

            string finalSource = $"{source}/api/{resource}";

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(o =>
            {
                o.UseSource(source, resource);
                o.SetTimeoutPeriod(timeoutSeconds);
                o.SetRetryOnTimeout(retryCount);
            });

            handlerFactory.ExtendApiHandler<ApiHandlerWrapper>().WithMockResponses(r =>
            {
                r.AddMockResponse(status, message)
                    .ResponseIsDelayed(timeoutSeconds + 2, retryCount - 1)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith(finalSource);
            });

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            IApiResponse response = Should.NotThrow(() => apiHandler.PerformRequest(Method.Get));

            #endregion
            #region Assert

            apiHandler.Resource.ShouldBe(resource);
            apiHandler.Source.ShouldBe(new Uri(finalSource));
            apiHandler.ResourcePath.ShouldBe(ApiHandlerOptionDefaults.ResourcePath);
            apiHandler.RetryCount.ShouldBe(retryCount);
            apiHandler.Timeout.ShouldBe(TimeSpan.FromSeconds(timeoutSeconds));

            response.WasSuccessful.ShouldBe(false);
            response.HasException.ShouldBe(false);
            response.Message.ShouldBe(message);
            response.Exception.ShouldBeNull();
            response.Status.ShouldBe(status);

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource", 2, 2)]
        [InlineData("http://test.source.com:8080", "path/path/resource", 3, 2)]
        public void UnSuccessfulBasicGetRequestWithTimeoutGeneric(string source, string resource, int retryCount, int timeoutSeconds)
        {
            #region Arrange

            const string message = "Exception occured whilst getting.";
            const Status status = Status.InternalServerError;

            string finalSource = $"{source}/api/{resource}";

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(o =>
            {
                o.UseSource(source, resource);
                o.SetTimeoutPeriod(timeoutSeconds);
                o.SetRetryOnTimeout(retryCount);
            });

            handlerFactory.ExtendApiHandler<ApiHandlerWrapper>().WithMockResponses(r =>
            {
                r.AddMockResponse(status, message)
                    .ResponseIsDelayed(timeoutSeconds + 2, retryCount - 1)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith(finalSource);
            });

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            IApiResponse<MockPersonDto> response = Should.NotThrow(() => apiHandler.PerformRequest<MockPersonDto>(Method.Get));

            #endregion
            #region Assert

            apiHandler.Resource.ShouldBe(resource);
            apiHandler.Source.ShouldBe(new Uri(finalSource));
            apiHandler.ResourcePath.ShouldBe(ApiHandlerOptionDefaults.ResourcePath);
            apiHandler.RetryCount.ShouldBe(retryCount);
            apiHandler.Timeout.ShouldBe(TimeSpan.FromSeconds(timeoutSeconds));

            response.WasSuccessful.ShouldBe(false);
            response.HasException.ShouldBe(false);
            response.Message.ShouldBe(message);
            response.Exception.ShouldBeNull();
            response.Status.ShouldBe(status);
            response.Result.ShouldBeNull();

            #endregion
        }


        [Theory]
        [InlineData("http://test.source.com", "resource", 0, 2)]
        [InlineData("http://test.source.com:8080", "path/path/resource", 1, 2)]
        public void TimedOutBasicGetRequest(string source, string resource, int retryCount, int timeoutSeconds)
        {
            #region Arrange

            string finalSource = $"{source}/api/{resource}";

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(o =>
            {
                o.UseSource(source, resource);
                o.SetTimeoutPeriod(timeoutSeconds);

                if(retryCount > 0)
                {
                    o.SetRetryOnTimeout(retryCount);
                }
            });

            handlerFactory.ExtendApiHandler<ApiHandlerWrapper>().WithMockResponses(r =>
            {
                r.AddMockResponse(Status.Ok)
                    .ResponseIsDelayed(timeoutSeconds + 2, retryCount)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith(finalSource);
            });

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            IApiResponse response = Should.NotThrow(() => apiHandler.PerformRequest(Method.Get));

            #endregion
            #region Assert

            apiHandler.Resource.ShouldBe(resource);
            apiHandler.Source.ShouldBe(new Uri(finalSource));
            apiHandler.ResourcePath.ShouldBe(ApiHandlerOptionDefaults.ResourcePath);
            apiHandler.RetryCount.ShouldBe(retryCount);
            apiHandler.Timeout.ShouldBe(TimeSpan.FromSeconds(timeoutSeconds));

            response.WasSuccessful.ShouldBe(false);
            response.HasException.ShouldBe(true);
            response.Message.ShouldBe(MessageHelper.RequestTimedOutRetryLimit);
            response.Exception.ShouldBeOfType<TimeoutException>();
            response.Status.ShouldBe(Status.None);

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource", 0, 2)]
        [InlineData("http://test.source.com:8080", "path/path/resource", 1, 2)]
        public void TimedOutBasicGetRequestGeneric(string source, string resource, int retryCount, int timeoutSeconds)
        {
            #region Arrange

            string finalSource = $"{source}/api/{resource}";

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(o =>
            {
                o.UseSource(source, resource);
                o.SetTimeoutPeriod(timeoutSeconds);

                if(retryCount > 0)
                {
                    o.SetRetryOnTimeout(retryCount);
                }
            });

            handlerFactory.ExtendApiHandler<ApiHandlerWrapper>().WithMockResponses(r =>
            {
                r.AddMockResponse(Status.Ok)
                    .ResponseIsDelayed(timeoutSeconds + 2, retryCount)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith(finalSource);
            });

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            IApiResponse<MockPersonDto> response = Should.NotThrow(() => apiHandler.PerformRequest<MockPersonDto>(Method.Get));

            #endregion
            #region Assert

            apiHandler.Resource.ShouldBe(resource);
            apiHandler.Source.ShouldBe(new Uri(finalSource));
            apiHandler.ResourcePath.ShouldBe(ApiHandlerOptionDefaults.ResourcePath);
            apiHandler.RetryCount.ShouldBe(retryCount);
            apiHandler.Timeout.ShouldBe(TimeSpan.FromSeconds(timeoutSeconds));

            response.WasSuccessful.ShouldBe(false);
            response.HasException.ShouldBe(true);
            response.Message.ShouldBe(MessageHelper.RequestTimedOutRetryLimit);
            response.Exception.ShouldBeOfType<TimeoutException>();
            response.Status.ShouldBe(Status.None);
            response.Result.ShouldBeNull();

            #endregion
        }

        #endregion
        #region Get Against Resource Tests

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com", "path/resource")]
        [InlineData("http://test.source.com", "path/path/resource")]
        [InlineData("http://test.source.com:80", "test/resource")]
        [InlineData("http://test.source.com:443", "path/resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void SuccessfulGetRequestAgainstResource(string source, string resource)
        {
            #region Arrange

            string fullSource = $"{source}/api/{resource}";
            string finalSource = $"{source}/api/";

            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source));

            handlerFactory.ExtendApiHandler<ApiHandlerWrapper>().WithMockResponses(r =>
            {
                r.AddMockResponse(Status.Ok)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith(fullSource);
            });

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            IApiResponse response = Should.NotThrow(() => apiHandler.PerformRequest(Method.Get, r => r.AgainstResource(resource)));

            #endregion
            #region Assert

            apiHandler.Resource.ShouldBeNull();
            apiHandler.Source.ShouldBe(new Uri(finalSource));
            apiHandler.ResourcePath.ShouldBe(ApiHandlerOptionDefaults.ResourcePath);
            apiHandler.RetryCount.ShouldBe(ApiHandlerOptionDefaults.RetryCount);
            apiHandler.Timeout.ShouldBe(ApiHandlerOptionDefaults.TimeoutPeriod);

            response.WasSuccessful.ShouldBe(true);
            response.HasException.ShouldBe(false);
            response.Message.ShouldBeNull();
            response.Exception.ShouldBeNull();
            response.Status.ShouldBe(Status.Ok);

            #endregion
        }

        [Theory]
        [InlineData("http://test.source.com", "resource")]
        [InlineData("http://test.source.com", "path/resource")]
        [InlineData("http://test.source.com", "path/path/resource")]
        [InlineData("http://test.source.com:80", "test/resource")]
        [InlineData("http://test.source.com:443", "path/resource")]
        [InlineData("http://test.source.com:8080", "path/path/resource")]
        public void SuccessfulBasicGetRequestAgainstResourceGeneric(string source, string resource)
        {
            #region Arrange

            string fullSource = $"{source}/api/{resource}";
            string finalSource = $"{source}/api/";


            using ApiHandlerFactory handlerFactory = new ApiHandlerFactory();

            handlerFactory.RegisterApiHandler<ApiHandlerWrapper>(
                o => o.UseSource(source));

            handlerFactory.ExtendApiHandler<ApiHandlerWrapper>().WithMockResponses(r =>
            {
                r.AddMockResponse(MockPersonDto.JohnSmith)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith(fullSource);
            });

            #endregion
            #region Act

            using ApiHandlerWrapper apiHandler = Should.NotThrow(() => handlerFactory.Build<ApiHandlerWrapper>());

            IApiResponse<MockPersonDto> response = Should.NotThrow(() => apiHandler.PerformRequest<MockPersonDto>(Method.Get, r => r.AgainstResource(resource)));

            #endregion
            #region Assert

            apiHandler.Resource.ShouldBeNull();
            apiHandler.Source.ShouldBe(new Uri(finalSource));
            apiHandler.ResourcePath.ShouldBe(ApiHandlerOptionDefaults.ResourcePath);
            apiHandler.RetryCount.ShouldBe(ApiHandlerOptionDefaults.RetryCount);
            apiHandler.Timeout.ShouldBe(ApiHandlerOptionDefaults.TimeoutPeriod);

            response.WasSuccessful.ShouldBe(true);
            response.HasException.ShouldBe(false);
            response.Message.ShouldBeNull();
            response.Exception.ShouldBeNull();
            response.Status.ShouldBe(Status.Ok);

            MockPersonDto person = response.Result;

            person.Age.ShouldBe(MockPersonDto.JohnSmith.Age);
            person.BirthDate.ShouldBe(MockPersonDto.JohnSmith.BirthDate);
            person.Name.ShouldBe(MockPersonDto.JohnSmith.Name);

            #endregion
        }

        #endregion
    }

}