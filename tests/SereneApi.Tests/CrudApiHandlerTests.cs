﻿using SereneApi.Abstraction;
using SereneApi.Abstraction.Enums;
using SereneApi.Extensions.Mocking;
using SereneApi.Factories;
using SereneApi.Tests.Mock;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SereneApi.Tests
{
    public class CrudApiHandlerTests
    {
        private readonly ICrudApi<MockPersonDto, long> _crudApiHandler;

        public CrudApiHandlerTests()
        {
            ApiHandlerFactory factory = new ApiHandlerFactory();

            factory.RegisterHandlerOptions<TestCrudApiHandler>(builder =>
            {
                builder.UseSource("http://localhost:8080", "Person");
            }).WithMockResponses(builder =>
            {
                builder
                    .AddMockResponse(MockPersonDto.BenJerry)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith("http://localhost:8080/api/Person/0");

                builder
                    .AddMockResponse(MockPersonDto.JohnSmith)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith("http://localhost:8080/api/Person/1");

                builder
                    .AddMockResponse(MockPersonDto.All)
                    .RespondsToRequestsWith(Method.Get)
                    .RespondsToRequestsWith("http://localhost:8080/api/Person");

                builder
                    .AddMockResponse(Status.Ok)
                    .RespondsToRequestsWith(Method.Delete)
                    .RespondsToRequestsWith("http://localhost:8080/api/Person/0");

                builder
                    .AddMockResponse(Status.NotFound, "Could not find a Person with an Id of 2")
                    .RespondsToRequestsWith(Method.Delete)
                    .RespondsToRequestsWith("http://localhost:8080/api/Person/2");

                builder
                    .AddMockResponse(MockPersonDto.BenJerry)
                    .RespondsToRequestsWith(Method.Post)
                    .RespondsToRequestsWith("http://localhost:8080/api/Person")
                    .RespondsToRequestsWith(MockPersonDto.BenJerry);

                builder
                    .AddMockResponse(Status.BadRequest, "This person has already been added.")
                    .RespondsToRequestsWith(Method.Post)
                    .RespondsToRequestsWith("http://localhost:8080/api/Person")
                    .RespondsToRequestsWith(MockPersonDto.JohnSmith);

                builder
                    .AddMockResponse(MockPersonDto.BenJerry)
                    .RespondsToRequestsWith(Method.Put)
                    .RespondsToRequestsWith("http://localhost:8080/api/Person")
                    .RespondsToRequestsWith(MockPersonDto.BenJerry);

                builder
                    .AddMockResponse(MockPersonDto.BenJerry)
                    .RespondsToRequestsWith(Method.Patch)
                    .RespondsToRequestsWith("http://localhost:8080/api/Person")
                    .RespondsToRequestsWith(MockPersonDto.BenJerry);

                builder
                    .AddMockResponse(Status.NotFound, "Could not find the specified user")
                    .RespondsToRequestsWith(Method.Patch)
                    .RespondsToRequestsWith("http://localhost:8080/api/Person")
                    .RespondsToRequestsWith(MockPersonDto.JohnSmith);
            });

            _crudApiHandler = factory.Build<TestCrudApiHandler>();
        }

        [Fact]
        public async Task GetTest()
        {
            IApiResponse<MockPersonDto> response = await _crudApiHandler.GetAsync(0);

            response.WasSuccessful.ShouldBe(true);
            response.Message.ShouldBeNull();
            response.HasException.ShouldBe(false);
            response.Exception.ShouldBeNull();

            MockPersonDto person = MockPersonDto.BenJerry;

            person.BirthDate.ShouldBe(MockPersonDto.BenJerry.BirthDate);
            person.Age.ShouldBe(MockPersonDto.BenJerry.Age);
            person.Name.ShouldBe(MockPersonDto.BenJerry.Name);

            response = await _crudApiHandler.GetAsync(1);

            response.WasSuccessful.ShouldBe(true);
            response.Message.ShouldBeNull();
            response.HasException.ShouldBe(false);
            response.Exception.ShouldBeNull();

            person = MockPersonDto.JohnSmith;

            person.BirthDate.ShouldBe(MockPersonDto.JohnSmith.BirthDate);
            person.Age.ShouldBe(MockPersonDto.JohnSmith.Age);
            person.Name.ShouldBe(MockPersonDto.JohnSmith.Name);
        }

        [Fact]
        public async Task GetAllTest()
        {
            IApiResponse<List<MockPersonDto>> response = await _crudApiHandler.GetAllAsync();

            response.Result.Count.ShouldBe(MockPersonDto.All.Count);
            response.Message.ShouldBeNull();
            response.Exception.ShouldBeNull();
            response.HasException.ShouldBe(false);
            response.WasSuccessful.ShouldBe(true);

            List<MockPersonDto> results = response.Result;

            for (int i = 0; i < results.Count; i++)
            {
                results[i].Name.ShouldBe(MockPersonDto.All[i].Name);
                results[i].Age.ShouldBe(MockPersonDto.All[i].Age);
                results[i].BirthDate.ShouldBe(MockPersonDto.All[i].BirthDate);
            }
        }

        [Fact]
        public async Task DeleteTest()
        {
            IApiResponse response = await _crudApiHandler.DeleteAsync(0);

            response.WasSuccessful.ShouldBe(true);
            response.Status.ShouldBe(Status.Ok);
            response.Message.ShouldBeNull();
            response.Exception.ShouldBeNull();
            response.HasException.ShouldBe(false);

            response = await _crudApiHandler.DeleteAsync(2);

            response.WasSuccessful.ShouldBe(false);
            response.Status.ShouldBe(Status.NotFound);
            response.Message.ShouldBe("Could not find a Person with an Id of 2");
            response.Exception.ShouldBeNull();
            response.HasException.ShouldBe(false);
        }

        [Fact]
        public async Task CreateTest()
        {
            IApiResponse<MockPersonDto> response = await _crudApiHandler.CreateAsync(MockPersonDto.BenJerry);

            response.WasSuccessful.ShouldBe(true);
            response.Message.ShouldBeNull();
            response.HasException.ShouldBe(false);
            response.Exception.ShouldBeNull();

            MockPersonDto person = MockPersonDto.BenJerry;

            person.BirthDate.ShouldBe(MockPersonDto.BenJerry.BirthDate);
            person.Age.ShouldBe(MockPersonDto.BenJerry.Age);
            person.Name.ShouldBe(MockPersonDto.BenJerry.Name);

            response = await _crudApiHandler.CreateAsync(MockPersonDto.JohnSmith);

            response.WasSuccessful.ShouldBe(false);
            response.Status.ShouldBe(Status.BadRequest);
            response.Message.ShouldBe("This person has already been added.");
            response.Exception.ShouldBeNull();
            response.HasException.ShouldBe(false);
        }

        [Fact]
        public async Task ReplaceTest()
        {
            IApiResponse<MockPersonDto> response = await _crudApiHandler.ReplaceAsync(MockPersonDto.BenJerry);

            response.WasSuccessful.ShouldBe(true);
            response.Message.ShouldBeNull();
            response.HasException.ShouldBe(false);
            response.Exception.ShouldBeNull();

            MockPersonDto person = MockPersonDto.BenJerry;

            person.BirthDate.ShouldBe(MockPersonDto.BenJerry.BirthDate);
            person.Age.ShouldBe(MockPersonDto.BenJerry.Age);
            person.Name.ShouldBe(MockPersonDto.BenJerry.Name);
        }

        [Fact]
        public async Task UpdateTest()
        {
            IApiResponse<MockPersonDto> response = await _crudApiHandler.UpdateAsync(MockPersonDto.BenJerry);

            response.WasSuccessful.ShouldBe(true);
            response.Message.ShouldBeNull();
            response.HasException.ShouldBe(false);
            response.Exception.ShouldBeNull();

            MockPersonDto person = MockPersonDto.BenJerry;

            person.BirthDate.ShouldBe(MockPersonDto.BenJerry.BirthDate);
            person.Age.ShouldBe(MockPersonDto.BenJerry.Age);
            person.Name.ShouldBe(MockPersonDto.BenJerry.Name);

            response = await _crudApiHandler.UpdateAsync(MockPersonDto.JohnSmith);

            response.WasSuccessful.ShouldBe(false);
            response.Status.ShouldBe(Status.NotFound);
            response.Message.ShouldBe("Could not find the specified user");
            response.Exception.ShouldBeNull();
            response.HasException.ShouldBe(false);
        }
    }
}
