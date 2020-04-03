﻿using System;
using System.Collections.Concurrent;
using System.Reactive.Subjects;
using OmniCore.Radios.RileyLink.Enumerations;

namespace OmniCore.Radios.RileyLink.Protocol
{
    public interface IRileyLinkResponse
    {
        RileyLinkResponseType ResponseType { get; }
        void Parse(byte[] responseData);
    }
}