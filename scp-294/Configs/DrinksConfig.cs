using Exiled.API.Enums;
using PlayerRoles;
using scp_294.Items;
using scp_294.Items.DrinkFeatures;
using System.Collections.Generic;

namespace scp_294.Configs
{
    public class DrinksConfig
    {

        /// <summary>
        /// Default drinks that will be loaded upon initializing the plugin.
        /// </summary>
        public List<Drink> Drinks { get; set; } = new()
        {
            new Drink()
            {
                Id = 1,
                Name = "hava icecegi",
                Aliases = { "nothing", "drink of cup", "drink of emptiness", "drink of vacuum", "HL3", "Half Life 3" },
                Description = "Bu şişenin içinde hiçbir şey yok."
            },
// AVSARTODO: çöküyor bu
/*
            new Drink()
            {
                Id = 2,
                Name = "scp icecegi",
                Description = "Kendini rastgele bir SCP olarak tanımla.",
                AppearanceOptions =
                {
                    ChangePlayerAppearance = true,
                    PossibleRoles = new()
                    {
                        RoleTypeId.Scp173,
                        RoleTypeId.Scp049,
                        RoleTypeId.Scp096,
                        RoleTypeId.Scp0492,
                        RoleTypeId.Scp106,
                        RoleTypeId.Scp939,
                    },
                    Duration = 10,
                    DisguiseMessage = "$new_role_name olarak görünüyorsun. <color=#ff0000>$time_left</color> saniyen kaldı.",
                    NoLongerInDisguise = "Artık SCP olarak görünmüyorsun."
                }
            },
*/
            new Drink()
            {
                Id = 3,
                Name = "scp173 icecegi",
                Aliases = { "173 İçeceği" },
                Description = "REEEEEEEEEEEEEEEEE.",
                Effects =
                {
                    new Effect()
                    {
                        Type = EffectType.MovementBoost,
                        Duration = 30f,
                        Intensity = new() { FixedAmount = 50 },
                        Chance = 100
                    }
                }
            },
            new Drink()
            {
                Id = 4,
                Name = "106 icecegi",
                Aliases = { "106 İçeceği" },
                Description = "Yaşlı herif salyası... Lezzetli!",
                ExtraEffects = { TeleportToPocketDimension = true }
            },
            new Drink()
            {
                Id = 5,
                Name = "cum icecegi",
                Aliases = { "cum" },
                Description = "Bu bir cum. Boşalt şişeyi dostum!",
                ExtraEffects = { PlaceTantrum = true }
            },
            new Drink()
            {
                Id = 6,
                Name = "nakarat meyvesi icecegi",
                Aliases = { "nakarat meyvesi icecegi" },
                Description = "Hiç Minecraft oynadın mı? O zaman ne olacağını biliyorsun.",
                TeleportManager = 
                {
                    PlayerTeleport = true,
                    CanPlayerEscapePocketDimension = false,
                    MessagePreventingPocketTeleport = "Cep boyutundan çıkman büyülü bir güç tarafından engelleniyor.",
                    Zone = ZoneType.Unspecified,
                    Room = RoomType.Unknown
                }
            },
            new Drink()
            {
                Id = 7,
                Name = "şeker içeceği",
                Aliases = { "şeker" },
                Description = "Koku duyularını bastırır. Tadı nasıl?",
                Effects =
                {
                    new Effect()
                    {
                        Type = EffectType.Vitality,
                        Intensity = new() { FixedAmount = 3 },
                        Duration = 40f,
                        Chance = 100
                    },
                    new Effect()
                    {
                        Type = EffectType.DamageReduction,
                        Intensity = new() { FixedAmount = 40 },
                        Duration = 30f,
                        Chance = 50
                    },
                    new Effect()
                    {
                        Type = EffectType.RainbowTaste,
                        Intensity = new() { FixedAmount = 1 },
                        Duration = 20f,
                        Chance = 50
                    },
                    new Effect()
                    {
                        Type = EffectType.Invigorated,
                        Intensity = new() { FixedAmount = 1 },
                        Duration = 10f,
                        Chance = 50
                    },
                    new Effect()
                    {
                        Type = EffectType.BodyshotReduction,
                        Intensity = new() { FixedAmount = 1 },
                        Duration = 0,
                        Chance = 50
                    },
                    new Effect()
                    {
                        Type = EffectType.MovementBoost,
                        Intensity = new() { FixedAmount = 10 },
                        Duration = 20f,
                        Chance = 50
                    }
                },
                ExtraEffects = { AhpGain = 20, HealAmount = 90 }
            },
            new Drink()
            {
                Id = 8,
                Name = "Gökkuşağı meyvesi içeceği",
                Description = "Her türlü lezzetle doludur.",
                Effects =
                {
                    new Effect()
                    {
                        Type = EffectType.Invigorated,
                        Intensity = new() { FixedAmount = 1 },
                        Duration = 10f,
                        Chance = 100
                    },
                    new Effect()
                    {
                        Type = EffectType.RainbowTaste,
                        Intensity = new() { FixedAmount = 1 },
                        Duration = 20f,
                        Chance = 100
                    },
                    new Effect()
                    {
                        Type = EffectType.BodyshotReduction,
                        Intensity = new() { FixedAmount = 1 },
                        Duration = 0,
                        Chance = 100
                    }
                },
                ExtraEffects = { AhpGain = 40, HealAmount = 30 }
            },
            new Drink()
            {
                Id = 9,
                Name = "yeşil şeker içeceği",
                Description = "Limonun eşsiz kokusu seni biraz cringe gösteriyor.",
                Effects =
                {
                    new Effect()
                    {
                        Type = EffectType.Invigorated,
                        Intensity = new() { FixedAmount = 1 },
                        Duration = 20f,
                        Chance = 100
                    },
                    new Effect()
                    {
                        Type = EffectType.MovementBoost,
                        Intensity = new() { FixedAmount = 10 },
                        Duration = 20f,
                        Chance = 100
                    }
                }
            },
            new Drink()
            {
                Id = 10,
                Name = "Mor şeker içeceği",
                Description = "Sulu üzüm kokusuna sahip. Ağzın sulanmaya başlıyor.",
                Effects =
                {
                    new Effect()
                    {
                        Type = EffectType.DamageReduction,
                        Intensity = new() { FixedAmount = 40 },
                        Duration = 30f,
                        Chance = 100
                    }
                },
                ExtraEffects = { Regeneration = { Rate = 1.5f, Duration = 20 } }
            },
            new Drink()
            {
                Id = 11,
                Name = "Kırmızı şeker içeceği",
                Description = "Odayı güçlü bir kiraz kokusu dolduruyor. Biraz... fazla güçlü.",
                ExtraEffects = { Regeneration = { Rate = 9f, Duration = 10 } }
            },
            new Drink()
            {
                Id = 12,
                Name = "Yeşil şeker içeceği",
                Description = "Meyve suyundan kötü bir bitkisel koku yayılıyor.",
                Effects =
                {
                    new Effect()
                    {
                        Type = EffectType.Vitality,
                        Intensity = new() { FixedAmount = 1 },
                        Duration = 45f,
                        Chance = 100
                    }
                },
                ExtraEffects = { Regeneration = { Rate = 2.25f, Duration = 80 } }
            },
            new Drink()
            {
                Id = 13,
                Name = "Mavi şeker içeceği",
                Description = "Yumuşak ve tatlı kokuyor, marşmelova benzer bir şey.",
                ExtraEffects = { AhpGain = 60 }
            },
            new Drink()
            {
                Id = 14,
                Name = "Pembe şeker içeceği",
                Description = "Çilek kokusu göründüğü kadar tatlı ve güzeldir.",
                ExtraEffects = { PlayerExplode = true }
            },
            new Drink()
            {
                Id = 15,
                Name = "Kan içeceği",
                Description = "Sanki kanının bir kısmını kaybetmiş gibi yorgun hissediyorsun.",
                ExtraEffects = { DamageAmount = 30 }
            },
            new Drink()
            {
                Id = 16,
                Name = "Hayat içeceği",
                Description = "Tazelenmiş hissediyorsun.",
                ExtraEffects = { HealAmount = 100 }              
            },
            new Drink()
            {
                Id = 17,
                Name = "Anti madde içeceği",
                Aliases = { "anti-matter", "void" },
                Description = "İçeceğin içine çekiliyormuş gibi hissediyorsun",
                ExtraEffects = { ExplodeOnDispensing = true }
            },
            new Drink()
            {
                Id = 18,
                Name = "Küçültme içeceği",
                Description = "Tanrım! tadı çok güzel geliyor",
                ScalingOptions =
                {
                    x = 0.5f,
                    y = 0.5f,
                    z = 0.5f,
                }
            },
            /*
            new Drink()
            {
                Id = 19,
                Name = "drink of chaos",
                Description = "I wonder what it tastes like",
                RoleManagerOptions =
                {
                    PlayerChangeRoles = true,
                    Roles =
                    {
                        RoleTypeId.ChaosRifleman,
                        RoleTypeId.ChaosMarauder,
                        RoleTypeId.ChaosConscript,
                        RoleTypeId.ChaosRepressor,
                    }
                },
            },
            */
        };
    }
}
