﻿using Exiled.API.Interfaces;
using scp_294.Items;
using System.ComponentModel;

namespace scp_294
{
    public class Config : IConfig
    {
        [Description("Set this to true if you want Random Mode enabled. Random Mode only allows the command '.scp294' and it gives you a random drink every time")]
        public bool RandomMode { get; set; } = false;

        [Description("Range to be able to use the machine")]
        public int Range { get; set; } = 2;

        [Description("Schematic Name. If you want to use a custom schematic, either change its name to scp294 or change this to the schematic's name")]
        public string SchematicName { get; set; } = "scp294";

        [Description("Message that appears once you approach Scp-294")]
        public string ApproachMessage { get; set; } = "You have approached SCP-294. Use .scp294 to get a drink";

        [Description("Message that appears after you get a drink")]
        public string EnjoyDrinkMessage { get; set; } = "<color=#00ff00>Enjoy your drink</color>";

        [Description("Message that appears if asked drink is not available")]
        public string OutOfRange { get; set; } = "<color=#ff0000>Out of range</color>";

        [Description("Message that appears if player is asked")]
        public string PlayerOutOfRange { get; set; } = "<color=#ff0000>you are not close enough to the machine</color>";

        [Description("Message that appears if player is not holding a coin")]
        public string PlayerNotHoldingCoin { get; set; } = "<color=#ff0000>you need to be holding coin</color>";

        [Description("Message that appears when an error occurs")]
        public string ErrorMessage { get; set; } = "<color=#ff0000>error occurred</color>";

        [Description("Message that appears if a player mistypes or uses the command incorrectly")]
        public string UsageMessage { get; set; } = "<color=#ff0000>Incorrect Usage. Try .scp294 [drink you want]. You can also use .scp294 list to print every drink currently available. If random mode is enabled, use .scp294 to get a random drink. (you cannot get a specific drink in random mode)</color>";

        public ThickJuice ThickJuice { get; set; } = new();
        public CandyJuice CandyJuice { get; set; } = new();
        public CandyRainbowJuice CandyRainbowJuice { get; set; } = new();
        public CandyYellowJuice CandyYellowJuice { get; set; } = new();
        public CandyPurpleJuice CandyPurpleJuice { get; set; } = new();
        public CandyRedJuice CandyRedJuice { get; set; } = new();
        public CandyGreenJuice CandyGreenJuice { get; set; } = new();
        public CandyBlueJuice CandyBlueJuice { get; set; } = new();
        public CandyPinkJuice CandyPinkJuice { get; set; } = new();
        public TeleportationDrink TeleportationDrink { get; set; } = new();
        public ScpDrink ScpDrink { get; set; } = new();
        public Scp173Drink Scp173Drink { get; set; } = new();
        public Scp106Drink Scp106Drink { get; set; } = new();

        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
    }
}
