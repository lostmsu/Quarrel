﻿using GalaSoft.MvvmLight.Ioc;
using Quarrel.Navigation;
using Quarrel.SubPages.Interfaces;
using Quarrel.ViewModels.Models.Bindables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Quarrel.SubPages
{
    public sealed partial class TopicPage : UserControl, IConstrainedSubPage
    {
        private ISubFrameNavigationService subFrameNavigationService = SimpleIoc.Default.GetInstance<ISubFrameNavigationService>();

        public TopicPage()
        {
            this.InitializeComponent();

            if (subFrameNavigationService.Parameter != null)
            {
                this.DataContext = subFrameNavigationService.Parameter;
            }
        }

        public BindableChannel ViewModel => DataContext as BindableChannel;

        public double MaxExpandedHeight => 200;
        public double MaxExpandedWidth => 800;
    }
}
