using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;

namespace TheFriend.Configuration {
    public class PluginConfig
    {
        // For more info on custom configs, see https://lethal.wiki/dev/intermediate/custom-configs
        public ConfigEntry<int> configWeight;
        public ConfigEntry<string> configMoons;
        public ConfigEntry<bool> configApparatusRage;
        public ConfigEntry<bool> configBaitVoicelines;
        public ConfigEntry<bool> configDareAttack;
        public ConfigEntry<bool> configFlashlightStun;
        public ConfigEntry<bool> configFakeoutAttack;
        public ConfigEntry<int> configProgressionSpeed;
        public ConfigEntry<bool> configIsolationAttack;
        public ConfigEntry<bool> configPhantomAttack;
        public ConfigEntry<bool> configDoorLockAttack;
        public ConfigEntry<bool> configFakeVoiceAttack;
        public ConfigEntry<float> configScreamVolume;
        public ConfigEntry<float> configMiscVolume;
        public ConfigEntry<int> configScreenshakeStrength;
        public ConfigEntry<float> configColorGradingStrength;
        public ConfigEntry<int> configHuntSpeed;
        public ConfigEntry<int> configRageHuntSpeed;
        public PluginConfig(ConfigFile Config)
        {
            configWeight = Config.Bind("General", "Spawn Weight", 5, "Chance of the Friend to spawn inside the facility.");
            configMoons = Config.Bind("General", "Moons", "All", "List of Moons on which the Friend can spawn.");

            configApparatusRage = Config.Bind("Behaviour", "Rage On Apparatus", true, "Whether the Friend should become aggressive upon pulling the Apparatus.");
            configBaitVoicelines = Config.Bind("Behaviour", "Enable Bait Voicelines", true, "Whether the Friend should use pre-recorded voicelines to bait the player. (ENGLISH ONLY)");
            configProgressionSpeed = Config.Bind("Behaviour", "Enable Dare Attack", 700, "How long until the Friend reaches maximum aggression. (in seconds)");
            configFlashlightStun = Config.Bind("Behaviour", "Enable Flashlight Stun", true, "Whether the Friend should be stunned by shining a flashlight. Causes it to become aggressive afterwards.");

            configDareAttack = Config.Bind("Attacks", "Enable Dare Attack", true, "Whether the Friend should use its Dare Attack. (WIP)");
            configFakeoutAttack = Config.Bind("Attacks", "Enable Fakeout Attack", true, "Whether the Friend should use its fake disappearing ability. (WIP)");
            configIsolationAttack = Config.Bind("Attacks", "Enable Isolation Attack", true, "Whether the Friend should use its Isolation ability. (WIP)");
            configPhantomAttack = Config.Bind("Attacks", "Enable Phantom Attack", true, "Whether the Friend should use its Phantom ability. (WIP)");
            configDoorLockAttack = Config.Bind("Attacks", "Enable DoorLock Attack", true, "Whether the Friend should use its Door Lock ability. (WIP)");
            configFakeVoiceAttack = Config.Bind("Attacks", "Enable Fake Voice Attack", true, "Whether the Friend should use its Fake Voice ability. (Also activates Cloning ability, since this is its only use) (WIP)");

            configScreamVolume = Config.Bind("Sound", "Scream Volume", 0.5f, "Volume of the Friend's Scream upon catching a player. (0 - 1)");
            configMiscVolume = Config.Bind("Sound", "Misc Volume", 0.5f, "Volume of the Friend's other sounds. (0 - 1)");

            configScreenshakeStrength = Config.Bind("Misc", "Screenshake Strength", 2, "Strength of the Friend's Screenshake upon raging. (1 - 3, 0 to disable)");
            configColorGradingStrength = Config.Bind("Misc", "Color Grading Strength", 0.5f, "Strength of the Friend's Color Grading upon pulling the apparatus. (0 - 1)");
            configHuntSpeed = Config.Bind("Misc", "Hunt Speed", 5, "How fast the fiend should go in a normal hunt.");
            configRageHuntSpeed = Config.Bind("Misc", "Rage Hunt Speed", 6, "How fast the fiend should go in a rage hunt.");
            ClearUnusedEntries(Config);
        }

        private void ClearUnusedEntries(ConfigFile cfg) {
            // Normally, old unused config entries don't get removed, so we do it with this piece of code. Credit to Kittenji.
            PropertyInfo orphanedEntriesProp = cfg.GetType().GetProperty("OrphanedEntries", BindingFlags.NonPublic | BindingFlags.Instance);
            var orphanedEntries = (Dictionary<ConfigDefinition, string>)orphanedEntriesProp.GetValue(cfg, null);
            orphanedEntries.Clear(); // Clear orphaned entries (Unbinded/Abandoned entries)
            cfg.Save(); // Save the config file to save these changes
        }
    }
}