using Exiled.API.Enums;
using Exiled.API.Features;
using System.ComponentModel;
using MEC;
using System.Collections.Generic;

namespace scp_294.Items.DrinkFeatures
{
    public class SpecialEffects
    {
        /// <summary>
        /// Gets or sets whether or not the player should explode after drinking.
        /// </summary>
        [Description("Whether or not the player explodes after drinking.")]
        public bool PlayerExplode { get; set; } = false;

        /// <summary>
        /// Gets or sets whether or not it will generate an explosion once you get the drink.
        /// </summary>
        [Description("Whether or not it will generate an explosion once you ask for the drink")]
        public bool ExplodeOnDispensing { get; set; } = false;

        /// <summary>
        /// Gets or sets the ahp gain.
        /// </summary>
        [Description("Whether or not the player gains Ahp. Set this to 0 if no Ahp.")]
        public int AhpGain { get; set; } = 0;

        /// <summary>
        /// Gets or sets how much stamina the player gets/loses.
        /// </summary>
        [Description("Whether or not the player gains/loses stamina. Value between -1 and 1. 0 for no change.")]
        public float StaminaChange { get; set; } = 0f;

        /// <summary>
        /// Gets or sets whether or not a tantrum is placed beneath the player.
        /// </summary>
        [Description("Whether or not tantrum is placed beneath the player.")]
        public bool PlaceTantrum { get; set; } = false;

        /// <summary>
        /// Gets or sets the heal amount.
        /// </summary>
        [Description("Whether or not the player receives HP.")]
        public int HealAmount { get; set; } = 0;

        /// <summary>
        /// Gets or sets the damage amount.
        /// </summary>
        [Description("How much damage the player will take on consuming the drink")]
        public int DamageAmount { get; set; } = 0;

        /// <summary>
        /// Gets or sets the <see cref="Regeneration"/> instance.
        /// </summary>
        [Description("Whether or not the player receives passive regeneration.")]
        public Regeneration Regeneration { get; set; } = new();

        /// <summary>
        /// Gets or sets whether or not the player should teleport to the pocket dimension.
        /// </summary>
        [Description("Whether or not the player gets teleported to pocket dimension.")]
        public bool TeleportToPocketDimension { get; set; } = false;

        [Description("Inflicts cardiac arrest on the intended user.")]
        public bool CardiacArrest { get; set; } = false;

        private IEnumerator<float> ApplyCardiacArrestHint(Player player, int duration)
		{
			player.EnableEffect(EffectType.CardiacArrest, duration);
			int time_left = duration;
			while (true)
			{
				player.ShowHint("Kalbini hiç iyi hissetmiyorsun :O");
				yield return Timing.WaitForSeconds(1f);

				time_left -= 1;

				if (time_left == 0)
					yield break;
			}
		}

        /// <summary>
        /// Apply the special effects to the player.
        /// </summary>
        /// <param name="player">The <see cref="Player"/> instance.</param>
        public void ApplySpecialEffects(Player player)
        {
            if (PlayerExplode) { player.Explode(); return; }
            if (AhpGain > 0) player.AddAhp(AhpGain, 100, 0f);
            if (StaminaChange != 0) player.StaminaStat.ModifyAmount(StaminaChange);
            if (PlaceTantrum) player.PlaceTantrum();
            if (HealAmount > 0) player.Heal(HealAmount);
            if (DamageAmount > 0) player.Hurt(DamageAmount);
            if (Regeneration.Rate > 0) Regeneration.ApplyRegeneration(player.ReferenceHub);
            if (TeleportToPocketDimension) player.EnableEffect(EffectType.PocketCorroding);
            if (CardiacArrest) { ApplyCardiacArrestHint(player, 20); }

        }
    }
}