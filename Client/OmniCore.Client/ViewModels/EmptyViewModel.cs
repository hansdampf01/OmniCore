﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OmniCore.Client.Views.Base;

namespace OmniCore.Client.ViewModels.Base
{
    public class EmptyViewModel : BaseViewModel
    {
        public override Task Initialize()
        {
            return Task.CompletedTask;
        }

        public override Task Dispose()
        {
            return Task.CompletedTask;
        }
    }
}