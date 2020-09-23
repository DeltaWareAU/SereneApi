﻿using System.Collections.Generic;

namespace SereneApi.Adapters.Testing.Profiling
{
    public interface IApiProfile
    {
        /// <summary>
        /// All requests made against the specific API.
        /// </summary>
        IReadOnlyList<IRequestProfile> Requests { get; }
    }
}
