﻿using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Loader;
using System.ComponentModel;
using System.IO;
using YamlDotNet.Serialization;

namespace scp_294.Configs
{
    public class Config : IConfig
    {

        /// <inheritdoc/>
        [Description("Whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc/>
        public bool Debug { get; set; } = false;

        /// <summary>
        /// Gets or sets the path of the drinks config folder.
        /// </summary>
        [Description("The path of the folder where the drinks will be stored.")]
        public string DrinksFolder { get; set; } = Path.Combine(Paths.Configs, "Drinks");

        /// <summary>
        /// Gets or sets the name of the drinks config file.
        /// </summary>
        [Description("The name of the file to load the drinks configs from")]
        public string DrinksFile { get; set; } = "global.yml";

        /// <summary>
        /// Gets or sets whether random mode is enabled or not.
        /// </summary>
        [Description("Whether or not random mode is enabled. Random Mode makes it so that every drink is random. This is false by default")]
        public bool RandomMode { get; set; } = false;

        /// <summary>
        /// Gets or sets the range of each machine.
        /// </summary>
        [Description("Range to be able to use the machine")]
        public int Range { get; set; } = 2;

        /// <summary>
        /// Gets or sets the schematic name.
        /// </summary>
        [Description("Schematic Name. If you want to use a custom schematic, either change its name to scp294 or change this to the schematic's name")]
        public string SchematicName { get; set; } = "scp294";

        /// <summary>
        /// Gets or sets the hint shown upon entering the machine range.
        /// </summary>
        [Description("Message that appears once you approach Scp-294")]
        public string ApproachMessage { get; set; } = "SCP-294'ün yakınlarındasın. .scp294 yazarak kendine bir içecek al!";

        /// <summary>
        /// Gets or sets the hint shown upon entering the machine range while random mode is enabled.
        /// </summary>
        [Description("Message that appears once you approach Scp-294 with random mode enabled")]
        public string ApproachMessageRandomMode { get; set; } = "SCP-294'ün yakınlarındasın. Gör ki klavye bozuk, konsola .scp294 yazarak rastgele içecek al";

        /// <summary>
        /// Gets or sets the message that appears after you get a drink.
        /// </summary>
        [Description("Message that appears after you get a drink")]
        public string EnjoyDrinkMessage { get; set; } = "<color=#00ff00>Tadını çıkar</color>";

        /// <summary>
        /// Gets or sets the message that appears if asked drink is not available.
        /// </summary>
        [Description("Message that appears if asked drink is not available")]
        public string OutOfRange { get; set; } = "<color=#ff0000>Öyle bir içecek yok</color>";

        /// <summary>
        /// Gets or sets the message that appears when the player is out of range.
        /// </summary>
        [Description("Message that appears if player is out of range")]
        public string PlayerOutOfRange { get; set; } = "<color=#ff0000>Makineye yakın değilsin</color>";

        /// <summary>
        /// Gets or sets the message that appears when the player is not holding a coin.
        /// </summary>
        [Description("Message that appears if player is not holding a coin")]
        public string PlayerNotHoldingCoin { get; set; } = "<color=#ff0000>Elinde para tutman lazım.</color>";

        /// <summary>
        /// Gets or sets the message that appears when an error occurs.
        /// </summary>
        [Description("Message that appears when an error occurs")]
        public string ErrorMessage { get; set; } = "<color=#ff0000>hata oluştu</color>";

        /// <summary>
        /// Gets or sets the message that contains the usage information.
        /// </summary>
        [Description("Message that appears if a player mistypes or uses the command incorrectly")]
        public string UsageMessage { get; set; } = "<color=#ff0000>Hatalı kullanım. Konsola .scp294 [istediğin içecek] yazarak alabilirsin. Şu anda mevcut olan her içeceği yazdırmak için .scp294 listesini de kullanabilirsiniz. Rastgele mod etkinse, rastgele içeceğinizi almak için yalnızca '.scp294' yazmanız gerekir.</color>";

        /// <summary>
        /// Gets or sets the <see cref="DrinksConfig"> instance.
        /// </summary>
        [YamlIgnore]
        public DrinksConfig DrinksConfig { get; set; } = null!;

        /// <summary>
        /// Load drink config from a separate file.
        /// </summary>
        public void LoadConfigs()
        {
            if (!Directory.Exists(DrinksFolder))
                Directory.CreateDirectory(DrinksFolder);

            string filePath = Path.Combine(DrinksFolder, DrinksFile);

            if (!File.Exists(filePath))
            {
                DrinksConfig = new DrinksConfig();
                File.WriteAllText(filePath, Loader.Serializer.Serialize(DrinksConfig));
            }
            else
            {
                DrinksConfig = Loader.Deserializer.Deserialize<DrinksConfig>(File.ReadAllText(filePath));
                File.WriteAllText(filePath, Loader.Serializer.Serialize(DrinksConfig));
            }
        }
    }
}
