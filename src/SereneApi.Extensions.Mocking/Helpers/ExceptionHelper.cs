﻿using SereneApi.Abstractions;
using System;
using SereneApi.Abstractions.Requests;

namespace SereneApi.Extensions.Mocking.Helpers
{
    internal static class ExceptionHelper
    {
        public static void MethodCannotBeCalledTwice()
        {
            throw new MethodAccessException("This method cannot be called twice.");
        }

        public static void EnsureParameterIsNotNull(object parameter, string paramName)
        {
            if(parameter == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void EnsureArrayIsNotEmpty(object[] array, string paramName)
        {
            if(array == null)
            {
                throw new ArgumentNullException(paramName);
            }

            if(array.Length == 0)
            {
                throw new ArgumentException($"{paramName} must not be Empty.");
            }
        }

        public static void EnsureCorrectMethod(Method method)
        {
            if(method == Method.NONE)
            {
                throw new ArgumentException("An invalid method was provided.");
            }
        }
    }
}
