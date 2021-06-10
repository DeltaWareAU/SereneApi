﻿using DependencyInjection.API;
using DependencyInjection.API.DTOs;
using SereneApi;
using SereneApi.Abstractions.Options;
using SereneApi.Abstractions.Request;
using SereneApi.Abstractions.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DependencyInjection.WebUi.Handlers
{
    public class StudentApiHandler: BaseApiHandler, IStudentApi
    {
        // This is important for Dependency Injection to work!
        // The Handler interface must be set as the generic for IApiHandlerOptions.
        // This is required so AspNet gets the right options for the current handler.
        public StudentApiHandler(IApiOptions<IStudentApi> options) : base(options)
        {
        }

        public Task<IApiResponse<StudentDto>> GetAsync(long studentId)
        {
            Request
                .WithMethod(Method.GET)
                .Perform();


            // This GET request will use the students Id as a parameter for the request.
            // http://localhost:8080/api/Students/{studentId}
            return PerformRequestAsync<StudentDto>(Method.GET, r => r
                .WithParameter(studentId));
        }

        public Task<IApiResponse<List<StudentDto>>> GetAllAsync()
        {
            // This is a simple GET request with no endpoint or parameters provided.
            // http://localhost:8080/api/Students
            return PerformRequestAsync<List<StudentDto>>(Method.GET);
        }

        public Task<IApiResponse<List<StudentDto>>> FindByGivenAndLastName(StudentDto student)
        {
            // In this example, only the Given and Last name values will used for the query.
            // http://localhost:8080/api/Students?GivenName=value&LastName=value
            return PerformRequestAsync<List<StudentDto>>(Method.GET, r => r
                .WithEndPoint("SearchBy/GivenAndLastName")
                .WithQuery(student, s => new { s.GivenName, s.LastName }));
        }

        public Task<IApiResponse> CreateAsync(StudentDto student)
        {
            // The StudentDto value will be passed to JSON and sent in the body of the request
            // http://localhost:8080/api/Students
            return PerformRequestAsync(Method.POST, r => r
                .AddInBodyContent(student));
        }

        public Task<IApiResponse<List<ClassDto>>> GetStudentClassesAsync(long studentId)
        {
            // Here we are using an Endpoint Template, allowing more complex APIs.
            // http://localhost:8080/api/Students/{studentId}/Classes
            return PerformRequestAsync<List<ClassDto>>(Method.GET, r => r
                .WithEndPoint("{0}/Classes").WithParameters(studentId));
        }
    }
}
