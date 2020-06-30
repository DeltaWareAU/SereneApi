﻿using DeltaWare.Dependencies;
using SereneApi.Interfaces;

namespace SereneApi.Types
{
    public class ApiHandlerExtensions: CoreOptions, IApiHandlerExtensions
    {
        public ApiHandlerExtensions()
        {
        }

        public ApiHandlerExtensions(IDependencyCollection dependencies) : base(dependencies)
        {
        }
    }
}
