using Exiled.API.Features;
using System;
using Exiled.Permissions.Extensions;
using MEC;
using System.Collections.Generic;
using System.Linq;

namespace LightPlug
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "LightPlug";
        public override string Prefix { get; } = "LP";
        public override string Author { get; } = "Dashtiss";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override void OnEnabled()
        {
            Timing.RunCoroutine(Timer());
            base.OnEnabled();

        }

        public override void OnDisabled()
        {
            base.OnDisabled();
        }
        public IEnumerator<float> Timer()
        {
            if (Round.IsLocked)
            {
                foreach (Player pl in Player.List.Where(pl => pl.CheckPermission("et.roundlockinfo")))
                {
                    pl.Broadcast(3, Config.RLEnabledMessage, Broadcast.BroadcastFlags.AdminChat);
                }
            }
            else
            {
                foreach (Player pl in Player.List.Where(pl => pl.CheckPermission("et.roundlockinfo")))
                {
                    pl.Broadcast(3, Config.RLDisabledMessage, Broadcast.BroadcastFlags.AdminChat);
                }
            }
            yield return Timing.WaitForSeconds(1f);
        }
    }
}