using System.Linq;
using PugMod;
using UnityEngine;

namespace StatsTracker {
    public class LoadoutsPlusMod : IMod {
        public static string MOD_VERSION = "1.0.0";
        public static string MOD_NAME = "Stats Tracker";
        public static string MOD_ID = "StatsTracker";
        
        public static LoadedMod ModInfo = null;
        public static AssetBundle AssetBundle;
        
        public void EarlyInit() {
            ModInfo = GetModInfo();
            
            if (ModInfo != null) {
                AssetBundle = ModInfo.AssetBundles[0];
                Debug.Log("Found mod info.");
            }
            else {
                Debug.LogError("Could not find mod info.");
            }
        }

        public void Init() {
            new GameObject("LoadoutsPlus_LoadoutsManager", typeof(LoadoutsManager));
            
            Debug.Log("Loaded " + LoadoutsPlusMod.MOD_NAME + " version " + LoadoutsPlusMod.MOD_VERSION + ".");
        }

        public void Shutdown() {
            Debug.Log("Unloaded " + LoadoutsPlusMod.MOD_NAME + " version " + LoadoutsPlusMod.MOD_VERSION + ".");
        }

        public void ModObjectLoaded(Object obj) {
            
        }

        public void Update() {
            
        }
        
        private LoadedMod GetModInfo() {
            return API.ModLoader.LoadedMods.FirstOrDefault(modInfo => modInfo.Handlers.Contains(this));
        }
    }
}