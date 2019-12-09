﻿using System;

namespace OmniCore.Model.Interfaces.Entities
{
    public interface IRadioAttributes
    {
        Guid DeviceUuid { get; set; }
        string DeviceIdReadable { get; }
        string DeviceName { get; set; }
        string UserDescription { get; set; }
    }
}
