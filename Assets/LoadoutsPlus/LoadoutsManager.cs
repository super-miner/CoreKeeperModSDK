using System.Collections.Generic;
using Flown.Common;
using I2.Loc;
using UnityEngine;

namespace StatsTracker {
    public class LoadoutsManager : MonoBehaviour {
        private const string ICONS_FOLDER_PATH = "Assets/LoadoutsPlus/Sprites/";

        public List<LoadoutTab> Tabs = new List<LoadoutTab>();
        
        private void Awake() {
            DontDestroyOnLoad(gameObject);
            
            Transform loadoutTabsContainer = GetLoadoutTabsContainer();
            if (loadoutTabsContainer == null) {
                Debug.LogError("Could not find the Loadout Tabs Container.");
                return;
            }

            for (int i = 0; i < loadoutTabsContainer.childCount; i++) {
                loadoutTabsContainer.GetChild(i).position += new Vector3(0.0f, 9.0f / 16.0f, 0.0f);
            }

            GameObject loadoutTabPrefab = GetLoadoutTab(loadoutTabsContainer).gameObject;

            CreateTabs(loadoutTabsContainer, loadoutTabPrefab);
        }

        private void Update() {
            foreach (LoadoutTab tab in Tabs) {
                tab.Update();
            }
        }

        private Transform GetLoadoutTabsContainer() {
            if (!Manager.ui) {
                Debug.LogError("Could not find UI Manager.");
                return null;
            }
            
            if (Manager.ui.characterWindow == null) {
                Debug.LogError("Could not find Character Window UI.");
                return null;
            }

            Transform root = Util.GetChildByName(Manager.ui.characterWindow.transform, "root");
            
            if (root == null) {
                Debug.LogError("Could not find Character Window UI Root.");
                return null;
            }

            Transform characterEquipmentContainer = Util.GetChildByName(root, "CharacterEquipment");
            
            if (characterEquipmentContainer == null) {
                Debug.LogError("Could not find Character Equipment Container.");
                return null;
            }
            
            return Util.GetChildByName(characterEquipmentContainer, "PresetTabs");
        }

        private Transform GetLoadoutTab(Transform loadoutTabsContainer) {
            return Util.GetChildByName(loadoutTabsContainer, "preset0Tab");
        }

        private void CreateTabs(Transform loadoutTabsContainer, GameObject loadoutTabPrefab) {
            CreateTab(loadoutTabsContainer, loadoutTabPrefab, new Vector3(0.0f, -(19.0f / 16.0f) * 3.0f, 0.0f), 4, new Vector2(10, 11), false);
            CreateTab(loadoutTabsContainer, loadoutTabPrefab, new Vector3(6.0f, 0.0f, 0.0f), 5, new Vector2(10, 11), true);
            CreateTab(loadoutTabsContainer, loadoutTabPrefab, new Vector3(6.0f, -(19.0f / 16.0f), 0.0f), 6, new Vector2(12, 11), true);
            CreateTab(loadoutTabsContainer, loadoutTabPrefab, new Vector3(6.0f, -(19.0f / 16.0f) * 2.0f, 0.0f), 7, new Vector2(14, 11), true);
            CreateTab(loadoutTabsContainer, loadoutTabPrefab, new Vector3(6.0f, -(19.0f / 16.0f) * 3.0f, 0.0f), 8, new Vector2(16, 11), true);
        }

        private void CreateTab(Transform loadoutTabsContainer, GameObject loadoutTabPrefab, Vector3 relativePosition, int tabNumber, Vector2 imageSize, bool flipMask) {
            GameObject customLoadoutTabGO = Instantiate<GameObject>(loadoutTabPrefab, loadoutTabsContainer);
            customLoadoutTabGO.transform.position += relativePosition;
            customLoadoutTabGO.name = $"LoadoutsPlus_ExtraLoadoutTab{tabNumber}";

            CharacterWindowTab customLoadoutTab = customLoadoutTabGO.GetComponent<CharacterWindowTab>();
            customLoadoutTab.hoverTitle = new LocalizedString($"LoadoutsPlus_Equipment{tabNumber}");

            Sprite icon = LoadoutsPlusMod.AssetBundle.LoadAsset<Sprite>($"{ICONS_FOLDER_PATH}LoadoutsPlus_Icon{tabNumber}.png");
            customLoadoutTab.icon.sprite = icon;
            customLoadoutTab.icon.size = imageSize;

            if (flipMask) {
                Transform mask1 = Util.GetChildByName(customLoadoutTabGO.transform, "mask");
                mask1.gameObject.SetActive(false);
                Transform mask2 = Util.GetChildByName(customLoadoutTabGO.transform, "mask2");
                mask2.gameObject.SetActive(false);
                Transform mask3 = Util.GetChildByName(customLoadoutTabGO.transform, "mask3");
                mask3.gameObject.SetActive(false);
            }
            
            customLoadoutTab.onClick.AddListener(() => {
                Manager.ui.characterWindow.SetActivePreset(tabNumber - 1);
            });
            
            Manager.ui.characterWindow.presetTabs.Add(customLoadoutTab);

            LoadoutTab tab = new LoadoutTab();
            tab.Tab = customLoadoutTab;
            tab.RightSide = flipMask;
            Tabs.Add(tab);
        }
    }
}