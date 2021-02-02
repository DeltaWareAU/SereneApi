﻿using SereneApi.Abstractions.Options;
using SereneApi.Abstractions.Request;
using SereneApi.Abstractions.Response;
using System.Threading.Tasks;

namespace SereneApi.Benchmark.API
{
    public class StudentApiHandler: BaseApiHandler, IStudentApi
    {
        public StudentApiHandler(IApiOptions options) : base(options)
        {
        }

        public Task<IApiResponse<StudentDto>> GetStudents()
        {
            return PerformRequestAsync<StudentDto>(Method.GET);
        }
    }
}
