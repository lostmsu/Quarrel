﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiscordAPI.Gateway.DownstreamEvents;

namespace Quarrel.Messages.Gateway
{
    public sealed class GatewayReadyMessage
    {
        public GatewayReadyMessage(Ready ready)
        {
            Ready = ready;
        }

        public Ready Ready { get; }
    }
}
