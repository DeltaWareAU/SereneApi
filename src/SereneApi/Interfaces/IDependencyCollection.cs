﻿namespace DeltaWare.SereneApi.Interfaces
{
    public interface IDependencyCollection
    {
        bool TryGetDependency<TDependency>(out TDependency dependencyInstance);
    }
}
