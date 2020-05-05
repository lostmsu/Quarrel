﻿// Copyright (c) Quarrel. All rights reserved.

using DiscordAPI.Models;
using Quarrel.ViewModels.Models.Bindables.Abstract;
using Quarrel.ViewModels.Models.Interfaces;

namespace Quarrel.ViewModels.Models.Bindables
{
    /// <summary>
    /// A Bindable wrapper on the <see cref="Embed"/> class.
    /// </summary>
    public class BindableEmbed : BindableModelBase<Embed>, IEmbed
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BindableEmbed"/> class.
        /// </summary>
        /// <param name="model">The base <see cref="Embed"/> object.</param>
        public BindableEmbed(Embed model) : base(model)
        {
        }
    }
}
