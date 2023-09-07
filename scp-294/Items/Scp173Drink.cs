﻿using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using Player = Exiled.Events.Handlers.Player;

namespace scp_294.Items
{
    [CustomItem(ItemType.AntiSCP207)]
    public class Scp173Drink : CustomItem
    {
        public override uint Id { get; set; } = 72;
        public override string Name { get; set; } = "drink of scp173";
        public override string Description { get; set; } = "REEEEEEEEEEEEEEEEE.";
        public override float Weight { get; set; } = 1f;
        public override ItemType Type { get; set; } = ItemType.AntiSCP207;
        public override SpawnProperties SpawnProperties { get; set; } = new()
        {
            Limit = 1, // Irrelevant: determines the maximum of how many will spawn (they will not spawn in the map)
        };

        protected override void SubscribeEvents()
        {
            Player.UsedItem += UsedItem;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Player.UsedItem -= UsedItem;
            base.UnsubscribeEvents();
        }

        private void UsedItem(UsedItemEventArgs ev)
        {
            if (Check(ev.Item))
            {
                ev.Player.DisableEffect(EffectType.AntiScp207);
                ev.Player.EnableEffect(EffectType.MovementBoost, 30);
                ev.Player.ChangeEffectIntensity(EffectType.MovementBoost, 50);
            }
        }
    }
}