﻿using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Usables.Scp330;
using Exiled.API.Enums;
using Player = Exiled.Events.Handlers.Player;
using System.ComponentModel;

namespace scp_294.Items
{
    [CustomItem(ItemType.AntiSCP207)]
    public class CandyGreenJuice : CustomItem
    {
        public override uint Id { get; set; } = 105;
        public override string Name { get; set; } = "drink of green candy";
        public override string Description { get; set; } = "A nasty herbal smell emits from the juice.";
        public override float Weight { get; set; } = 1f;
        public override ItemType Type { get; set; } = ItemType.AntiSCP207;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
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

        [Description("By how much the base effect will be multiplied: base effect * Times")]
        public float Times { get; set; } = 1.5f;

        private void UsedItem(UsedItemEventArgs ev)
        {
            if (Check(ev.Item))
            {
                ev.Player.DisableEffect(EffectType.AntiScp207);

                Scp330Bag.AddSimpleRegeneration(ev.Player.ReferenceHub, 1.5f * Times, 80f);
                ev.Player.EnableEffect(EffectType.Vitality, 30f * Times);
            }
        }
    }
}