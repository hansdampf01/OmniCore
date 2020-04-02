﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;
using OmniCore.Model.Interfaces.Common;
using OmniCore.Model.Interfaces.Services;
using OmniCore.Model.Interfaces.Services.Internal;
using OmniCore.Services;
using OmniCore.Services.Integration;

namespace OmniCore.Services
{
    public static class Initializer
    {
        public static ICoreContainer<IServerResolvable> WithDefaultServices
            (this ICoreContainer<IServerResolvable> container)
        {
            return container
                .One<ICoreRepositoryService, CoreRepositoryService>()
                .One<ICoreConfigurationService, CoreConfigurationService>()
                .One<ICorePodService, CorePodService>()
                .One<ICoreAutomationService, CoreAutomationService>()
                .One<ICoreIntegrationService, CoreIntegrationService>()
                .One<IIntegrationComponent, MqttIntegration>(nameof(MqttIntegration))
                .One<IIntegrationComponent, XdripIntegration>(nameof(XdripIntegration));
        }
    }
}