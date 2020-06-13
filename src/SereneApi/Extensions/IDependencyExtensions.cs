﻿using SereneApi.Interfaces;
using System;

// Do note change namespace
// ReSharper disable once CheckNamespace
namespace SereneApi.Types
{
    internal static class IDependencyExtensions
    {
        /// <summary>
        /// Gets an Instance of the <see cref="IDependency"/>
        /// </summary>
        /// <typeparam name="TDependency">The Type the <see cref="IDependency"/> Instance will be casted too</typeparam>
        /// <param name="dependency">The <see cref="IDependency"/> the Instance will be retrieved from</param>
        public static TDependency GetInstance<TDependency>(this IDependency dependency)
        {
            if (dependency is IDependency<TDependency> dependencyValue && dependencyValue.Type == typeof(TDependency))
            {
                return dependencyValue.Instance;
            }

            if (dependency.Instance.GetType() == typeof(TDependency))
            {
                return (TDependency)dependency.Instance;
            }

            throw new ArgumentException($"The dependency must be of type {typeof(IDependency<TDependency>)}");
        }
    }
}
