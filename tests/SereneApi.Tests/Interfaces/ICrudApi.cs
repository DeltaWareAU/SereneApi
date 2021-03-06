﻿using SereneApi.Abstractions.Handler;
using SereneApi.Tests.Mock;

namespace SereneApi.Tests.Interfaces
{
    public interface ICrudApi : ICrudApi<MockPersonDto, long>
    {
    }
}
