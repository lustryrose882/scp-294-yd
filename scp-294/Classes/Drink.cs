﻿using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Collections.Generic;
using System.ComponentModel;
using Player = Exiled.Events.Handlers.Player;
using Exiled.API.Enums;
using System;
using Exiled.API.Features;
using CustomPlayerEffects;

namespace scp_294.Classes
{
    public class Drink : CustomItem
    {
        [Description("Name of the drink, this is what the player has to write in order to receive it")]
        public override string Name { get; set; } = "drink of scp173";

        public string[] Aliases { get; set; } = { "drink of 173" };

        [Description("Description of the drink, this is what appears when holding the drink")]
        public override string Description { get; set; } = "REEEEEEEEEE";

        [Description("Whether or not the drink is enabled on your server. If this is set to false, drinks won't even register so you won't be able to have it through RA")]
        public bool IsEnabled { get; set; } = true;

        [Description("Make sure this is different from any other drink/Custom item")]
        public override uint Id { get; set; } = 69;

        public override ItemType Type { get; set; } = ItemType.AntiSCP207;

        [Description("Weight of the drink. The higher the value the slower you move when holding it")]
        public override float Weight { get; set; } = 1f;

        [Description("Ignore this. Unless you want drinks to spawn in the map, kinda defies the whole point of the machine.")]
        public override SpawnProperties SpawnProperties { get; set; } = new();

        [Description("Whether or not, the anticola effect should be removed")]
        public bool RemoveAntiColaEffect { get; set; } = true;

        [Description("Whether or not the player should explode")]
        public bool ShouldPlayerExplode { get; set; } = false;

        [Description("Whether or not the a tantrum puddle from scp173 spawns")]
        public bool SpawnScp173Tantrum { get; set; } = false;

        [Description("List of effects that will be applied to the player")]
        public List<Effect> Effects { get; set; } = new()
        {
            new Effect()
            {
                Type = EffectType.MovementBoost,
                Duration = 30,
                Intensity = new Intensity()
                {
                    FixedAmount = 20
                },
                Chance = 100,
            }
        };

        [Description("Whether or not the player will be teleported to the pocket dimension")]
        public bool TeleportToPocketDimension { get; set; } = false;

        [Description("Teleport Options")]
        public Teleport TeleportOptions { get; set; } = new()
        {
            PlayerTeleport = false,
            Zone = ZoneType.Unspecified,
            Room = RoomType.Unknown
        };

        [Description("Appearance Options")]
        public AppearanceManager AppearanceOptions { get; set; } = new()
        {
            ChangePlayerAppearance = false,
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
            if (!Check(ev.Item)) return;

            if(RemoveAntiColaEffect) RemoveAntiScp207(ev.Player);

            if (SpawnScp173Tantrum) ev.Player.PlaceTantrum();

            if (TeleportToPocketDimension) ev.Player.EnableEffect(EffectType.PocketCorroding);

            if (TeleportOptions.PlayerTeleport) ev.Player.Teleport(TeleportOptions.GetTeleportLocation());

            if (AppearanceOptions.ChangePlayerAppearance) AppearanceOptions.ChangeAppearance(ev.Player);

            if (ShouldPlayerExplode)
            {
                ev.Player.Explode();
                return;
            }

            ApplyEffects(ev.Player);
        }

        private void ApplyEffects(Exiled.API.Features.Player player)
        {
            foreach(Effect effect in Effects)
            {
                Log.Debug($"Trying to apply {effect.Type}. Chance: {effect.Chance}");
                if(Roll(effect.Chance))
                {
                    Log.Debug($"Applying effect to player. Duration: {effect.Duration}. Intensity fixed amount: {effect.Intensity.FixedAmount}. Intensity range: {effect.Intensity.LowestAmount} to {effect.Intensity.HighestAmount}");
                    player.ChangeEffectIntensity(effect.Type, (byte)effect.Intensity.GetIntensity(), effect.Duration);
                }
            }
        }

        private bool Roll(int chance) => new Random().Next(0, 101) < chance;

        private void RemoveAntiScp207(Exiled.API.Features.Player player)
        {
            int intensity = player.GetEffectIntensity<Scp207>();

            if (intensity > 0)
            {
                player.ChangeEffectIntensity<Scp207>(0);
            }

            player.ChangeEffectIntensity<AntiScp207>(0);
            player.ChangeEffectIntensity<Scp207>((byte)intensity);
        }
    }
}
