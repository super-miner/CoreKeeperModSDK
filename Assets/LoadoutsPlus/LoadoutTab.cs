using UnityEngine;

namespace StatsTracker {
    public class LoadoutTab {
        public CharacterWindowTab Tab;
        public bool RightSide;

        public void Update() {
            if (RightSide) {
                if (Manager.ui.characterWindow.statsWindow.isShowing) {
                    Tab.gameObject.SetActive(false);
                }
                else {
                    Tab.gameObject.SetActive(true);
                }
            }
        }
    }
}