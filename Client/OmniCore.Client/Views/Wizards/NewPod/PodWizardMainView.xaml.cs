﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OmniCore.Client.ViewModels.Wizards;
using OmniCore.Client.Views.Base;
using OmniCore.Model.Interfaces.Platform.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OmniCore.Client.Views.Wizards.NewPod
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PodWizardMainView : IView
    {
        public PodWizardMainView()
        {
            InitializeComponent();
        }
    }
}