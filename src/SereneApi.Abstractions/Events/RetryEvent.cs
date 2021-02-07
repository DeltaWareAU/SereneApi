﻿using SereneApi.Abstractions.Handler;
using SereneApi.Abstractions.Request;
using System;

namespace SereneApi.Abstractions.Events
{
    public class RetryEvent: IEventListener<IApiHandler, Guid>
    {
        public DateTimeOffset EventTime { get; } = DateTimeOffset.Now;

        public IApiHandler Reference { get; }

        public Guid Value { get; }

        public RetryEvent(IApiHandler reference, IApiRequest request)
        {
            Reference = reference;
            Value = request.Identity;
        }
    }
}
