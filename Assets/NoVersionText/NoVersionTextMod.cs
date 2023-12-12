using Flown.Common;
using PugMod;
using UnityEngine;

namespace NoVersionText {
    public class NoVersionTextMod : IMod {
        public static string MOD_VERSION = "1.0.0";
        public static string MOD_NAME = "No Version Text";
        public static string MOD_ID = "NoVersionText";

        private static bool hidVersionText = false;

        public void EarlyInit() {
            
        }

        public void Init() {
        	Debug.Log($"[{MOD_NAME}]: Loaded {MOD_NAME} version {MOD_VERSION}.");
        }

        public void Shutdown() {
        	Debug.Log($"[{MOD_NAME}]: Unloaded {MOD_NAME} version {MOD_VERSION}.");
        }

        public void ModObjectLoaded(UnityEngine.Object obj) {
        	
        }

        public void Update() {
	        if (!hidVersionText) {
		        Transform versionText = FindVersionText();
		        
		        if (versionText == null) {
			        Debug.Log($"[{MOD_NAME}]: Could not find PreviewVersionText.");
			        return;
		        }
		        
		        versionText.gameObject.SetActive(false);

		        hidVersionText = true;
	        }
        }
        
        Transform FindVersionText() {
	        if (!Manager.ui) {
		        Debug.Log($"[{MOD_NAME}]: Could not find UI Manager.");
		        return null;
	        }

	        Transform renderingParent = Manager.ui.transform.parent.parent.GetChild(2); // GlobalObjects (Main Manager)(Clone)/Rendering

	        Transform UICamera = Util.GetChildByName(renderingParent, "UI Camera");

	        if (UICamera == null) {
		        Debug.Log($"[{MOD_NAME}]: Could not find UI Camera.");
		        return null;
	        }

	        return Util.GetChildByName(UICamera, "PreviewVersionText");
        }
    }
}