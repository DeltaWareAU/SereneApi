﻿using System.IO;
using System.Threading.Tasks;

namespace SereneApi.Abstractions.Content
{
    public interface IApiResponseContent
    {
        Stream GetContentStream();

        Task<Stream> GetContentStreamAsync();

        string GetContentString();

        Task<string> GetContentStringAsync();
    }
}
