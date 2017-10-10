using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminAbilities
{
    public class AdminAbilities : RocketPlugin
    {
        protected override void Load()
        {
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
        }

        private void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            if(player.HasPermission("adminabilities"))
            {
                Provider.send(player.Player.channel.owner.playerID.steamID, ESteamPacket.ADMINED, new byte[]
                    {
                                7,
                                (byte)Provider.clients.IndexOf(player.Player.channel.owner)
                    }, 2, 0);
            }
        }
    }
}
