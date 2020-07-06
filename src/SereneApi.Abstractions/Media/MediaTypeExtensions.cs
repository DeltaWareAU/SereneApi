﻿using System;

namespace SereneApi.Abstractions.Media
{
    public static class MediaTypeExtensions
    {
        public static string GetTypestring(this MediaType mediaType)
        {
            return mediaType switch
            {
                MediaType.Json => "application/json",
                MediaType.FormUrlEncoded => "application/x-www-form-urlencoded",
                _ => throw new ArgumentOutOfRangeException(nameof(mediaType), mediaType, null)
            };
        }
    }
}
