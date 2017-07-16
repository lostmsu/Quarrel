﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Discord_UWP.SharedModels;
using Microsoft.Toolkit.Uwp.UI.Animations;
using GuildChannel = Discord_UWP.CacheModels.GuildChannel;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Discord_UWP.Controls
{
    public sealed partial class GuildControl : UserControl
    {
        public string Id
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public static readonly DependencyProperty IdProperty = DependencyProperty.Register(
            nameof(Id),
            typeof(string),
            typeof(GuildControl),
            new PropertyMetadata("", OnPropertyChangedStatic));

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register(
            nameof(Name),
            typeof(string),
            typeof(GuildControl),
            new PropertyMetadata("", OnPropertyChangedStatic));

        public string ImageUrl
        {
            get { return (string)GetValue(ImageUrlProperty); }
            set { SetValue(ImageUrlProperty, value); }
        }
        public static readonly DependencyProperty ImageUrlProperty = DependencyProperty.Register(
            nameof(ImageUrl),
            typeof(string),
            typeof(GuildControl),
            new PropertyMetadata("", OnPropertyChangedStatic));

        public int NotificationCount
        {
            get { return (int)GetValue(NotificationCountProperty); }
            set { SetValue(NotificationCountProperty, value); }
        }
        public static readonly DependencyProperty NotificationCountProperty = DependencyProperty.Register(
            nameof(NotificationCount),
            typeof(int),
            typeof(GuildControl),
            new PropertyMetadata(0, OnPropertyChangedStatic));

        public bool IsUnread
        {
            get { return (bool)GetValue(IsUnreadProperty); }
            set { SetValue(IsUnreadProperty, value); }
        }
        public static readonly DependencyProperty IsUnreadProperty = DependencyProperty.Register(
            nameof(IsUnread),
            typeof(bool),
            typeof(GuildControl),
            new PropertyMetadata(false, OnPropertyChangedStatic));

        public bool IsMuted
        {
            get { return (bool)GetValue(IsMutedProperty); }
            set { SetValue(IsMutedProperty, value); }
        }
        public static readonly DependencyProperty IsMutedProperty = DependencyProperty.Register(
            nameof(IsMuted),
            typeof(bool),
            typeof(GuildControl),
            new PropertyMetadata(false, OnPropertyChangedStatic));

        public bool IsDM
        {
            get { return (bool)GetValue(IsDMProperty); }
            set { SetValue(IsDMProperty, value); }
        }
        public static readonly DependencyProperty IsDMProperty = DependencyProperty.Register(
            nameof(IsDM),
            typeof(bool),
            typeof(GuildControl),
            new PropertyMetadata(false, OnPropertyChangedStatic));

        private static void OnPropertyChangedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as GuildControl;

            // Defer to the instance method.
            instance?.OnPropertyChanged(d, e.Property);
        }

        private async void OnPropertyChanged(DependencyObject d, DependencyProperty prop)
        {
            if (prop == IsUnreadProperty)
            {
                if (IsUnread && !IsMuted)
                {
                    UnreadIndicator.Visibility = Visibility.Visible;
                }
                else
                {
                    UnreadIndicator.Visibility = Visibility.Collapsed;
                }
            }
            //if (prop == IsMutedProperty)
            //{
            //    if (IsMuted)
            //    {
            //        ChannelName.Opacity = 0.5;
            //        MuteIcon.Visibility = Visibility.Visible;
            //    }
            //    else
            //    {
            //        MuteIcon.Visibility = Visibility.Collapsed;
            //    }
            //}
            if (prop == NotificationCountProperty)
            {
                if (NotificationCount > 0)
                {
                    NotificationBorder.Visibility = Visibility.Visible;
                    NotificationCounter.Text = NotificationCount.ToString();
                    NotificationScale.CenterX = NotificationBorder.ActualWidth / 2;
                    ShowBadge.Begin();
                }
                else
                {
                    NotificationScale.CenterX = NotificationBorder.ActualWidth / 2;
                    HideBadge.Begin();
                }
            }
            if (prop == NameProperty)
            {
                ToolTipService.SetToolTip(this, Name);
            }
            if (prop == ImageUrlProperty)
            {
                if (ImageUrl != "empty" && ImageUrl != "")
                {
                    GuildImageBrush.ImageSource = new BitmapImage(new Uri(ImageUrl));
                }
                else if (ImageUrl == "empty")
                {
                    if (Name != "")
                    {
                        TextIcon.Text = Name[0].ToString();
                        TextIcon.Visibility = Visibility.Visible;
                    }
                }
            }
            if (prop == IsDMProperty)
            {
                if (IsDM)
                {
                    DMView.Visibility = Visibility.Visible;
                    GuildImageBackdrop.Visibility = Visibility.Collapsed;
                }
            }
        }

        public GuildControl()
        {
            this.InitializeComponent();
            ToolTipService.SetToolTip(this, Name);
            this.Holding += OpenMenuFlyout;
            this.RightTapped += OpenMenuFlyout;
        }

        private void OpenMenuFlyout(object sender, RightTappedRoutedEventArgs e)
        {
            e.Handled = true;
            if (e.PointerDeviceType != PointerDeviceType.Touch)
                App.ShowMenuFlyout(this, App.Type.Guild, Id, null, e.GetPosition(this));
        }

        private void OpenMenuFlyout(object sender, HoldingRoutedEventArgs e)
        {
            e.Handled = true;
            if (e.HoldingState == HoldingState.Started)
                App.ShowMenuFlyout(this, App.Type.Guild, Id, null, e.GetPosition(this));
        }

        private void HideBadge_Completed(object sender, object e)
        {
            NotificationBorder.Visibility = Visibility.Collapsed;
        }
    }
}