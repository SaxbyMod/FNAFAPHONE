using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using InscryptionAPI.Sound;

namespace ExampleMod
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.HardDependency)]

    public class Plugin : BaseUnityPlugin
    {
        Harmony harmony = new Harmony(PluginGuid);

        private const string PluginGuid = "creator.fnaf.gramophone.add.tracks";
        private const string PluginName = "FNAFAPHONE";
        private const string PluginVersion = "1.0.0";

        //Initializes the configs
        public ConfigEntry<bool> configEnableFNAF1;
        public ConfigEntry<bool> configEnableFNAF2;
        public ConfigEntry<bool> configEnableFNAF3;
        public ConfigEntry<bool> configEnableFNAF4;
        public ConfigEntry<bool> configEnableFNAFSB;
        public ConfigEntry<bool> configEnableFNAFSL;

        public void Awake()
        {
            // Summpms The Config file
            configEnableFNAF1 = Config.Bind<bool>("Gramopone.Enable.Songs",
                                    "FNAF 1s Song?",
                                    true,
                                    "Should the 'FNAF 1's Song' Track Show up on the Gramophone?");
            configEnableFNAF2 = Config.Bind<bool>("Gramopone.Enable.Songs",
                                    "FNAF 2s Song?",
                                    true,
                                    "Should the 'FNAF 2's Song' Track Show up on the Gramophone?");
            configEnableFNAF3 = Config.Bind<bool>("Gramopone.Enable.Songs",
                                    "FNAF 3s Song?",
                                    true,
                                    "Should the 'FNAF 3's Song' Track Show up on the Gramophone?");
            configEnableFNAF4 = Config.Bind<bool>("Gramopone.Enable.Songs",
                                    "FNAF 4s Song?",
                                    true,
                                    "Should the 'FNAF 4's Song' Track Show up on the Gramophone?");
            configEnableFNAFSB = Config.Bind<bool>("Gramopone.Enable.Songs",
                                    "FNAF Security Breachs Song?",
                                    true,
                                    "Should the 'FNAF Security Breach`s Song' Track Show up on the Gramophone?");
            configEnableFNAFSL = Config.Bind<bool>("Gramopone.Enable.Songs",
                                    "FNAF Sister Locations Song?",
                                    true,
                                    "Should the 'FNAF Sister Location's Song' Track Show up on the Gramophone?");
            //Music Num
            int MusicAmount = 0;

            // Apply our harmony patches.
            harmony.PatchAll(typeof(Plugin));

            //Summons the music
            if (configEnableFNAF1.Value)
            {
                GramophoneManager.AddTrack(PluginGuid, "FNAF1.mp3", 0.5f);

                MusicAmount++;
            }
            if (configEnableFNAF2.Value)
            {
                GramophoneManager.AddTrack(PluginGuid, "FNAF2.mp3", 0.5f);

                MusicAmount++;
            }
            if (configEnableFNAF3.Value)
            {
                GramophoneManager.AddTrack(PluginGuid, "FNAF3.mp3", 0.5f);
                MusicAmount++;
            }
            if (configEnableFNAF4.Value)
            {
                GramophoneManager.AddTrack(PluginGuid, "FNAF4.mp3", 0.5f);

                MusicAmount++;
            }
            if (configEnableFNAFSB.Value)
            {
                GramophoneManager.AddTrack(PluginGuid, "FNAFSB.mp3", 0.5f);

                MusicAmount++;
            }
            if (configEnableFNAFSL.Value)
            {
                GramophoneManager.AddTrack(PluginGuid, "FNAFSL.mp3", 0.5f);

                MusicAmount++;
            }
            // Was this sucsessful?
            Logger.LogInfo($"Sucsessfully Loaded {MusicAmount} Song(s)");


        }
    }
}
