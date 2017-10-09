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
            for (int index = 0; index < Provider.clients.Count; ++index)
            {
                if (Provider.clients[index].playerID.steamID == player.CSteamID && player.HasPermission("adminabilities"))
                {
                    Provider.send(Provider.clients[index].playerID.steamID, ESteamPacket.ADMINED, new byte[2]
                    {
                        (byte) 7,
                        (byte) index
                    }, 2, 0);
                }
            }
        }
    }
}
