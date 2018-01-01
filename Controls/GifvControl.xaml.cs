﻿using Discord_UWP.SharedModels;
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

namespace Discord_UWP.Controls
{
    public sealed partial class GifvControl : UserControl
    {
        private DependencyProperty EmbedContentProperty;

        public Embed EmbedContent
        {
            get { return (Embed)GetValue(EmbedContentProperty); }
            set { mediaelement.Source = new Uri(value.Video.Url); }
        }

        public GifvControl()
        {
            this.InitializeComponent();
        }
        private void mediaelement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaelement.Position = TimeSpan.Zero;
            mediaelement.Play();
        }
    }
}