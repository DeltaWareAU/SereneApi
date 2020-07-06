﻿using SereneApi.Abstractions.Configuration;
using SereneApi.Abstractions.Helpers;
using System;

namespace SereneApi.Abstractions.Types
{
    public class Connection: IConnectionSettings
    {
        public Uri BaseAddress { get; }

        public string Source { get; }

        public string Resource { get; }

        public string ResourcePath { get; }

        public int Timeout { get; set; }

        public int RetryAttempts { get; set; }

        public Connection(string baseAddress, string resource = default, string resourcePath = default)
        {
            ExceptionHelper.EnsureParameterIsNotNull(baseAddress, nameof(baseAddress));

            baseAddress = SourceHelpers.EnsureSourceSlashTermination(baseAddress);

            BaseAddress = new Uri(baseAddress);

            Resource = SourceHelpers.EnsureSourceNoSlashTermination(resource);
            ResourcePath = SourceHelpers.EnsureSourceSlashTermination(resourcePath);

            Source = $"{BaseAddress}{ResourcePath}{Resource}";
        }
    }
}
