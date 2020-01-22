﻿using Microsoft.Toolkit.Uwp.UI.Animations;
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
using GalaSoft.MvvmLight.Messaging;
using Quarrel.Messages.Navigation.SubFrame;
using Quarrel.ViewModels.Models.Bindables;
using Quarrel.SubPages;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Quarrel.Controls.Channels
{
    public sealed partial class ChannelListHeader : UserControl
    {
        public ChannelListHeader()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) =>
            {
                this.Bindings.Update();

                if (ViewModel != null)
                {
                    if (ViewModel.Model.BannerUri == null)
                        rootButton.Height = 48;
                    else
                        rootButton.Height = 64;
                }
            };
        }

        public BindableGuild ViewModel => DataContext as BindableGuild;

        private async void ImageEx_ImageExOpened(object sender, Microsoft.Toolkit.Uwp.UI.Controls.ImageExOpenedEventArgs e)
        {
            await Banner.Fade(1, 200).StartAsync();
        }
    }
}
