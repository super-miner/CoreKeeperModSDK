using System;
using HarmonyLib;
using StatsTracker.Systems;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace LoadoutsPlus.Patches {
    [HarmonyPatch]
    public static class EquipmentHandlerPatch {
        public static EquipmentHandler equipmentHandler;
        public static int presetIndex = -1;
        
        [HarmonyPatch(typeof(EquipmentHandler), MethodType.Constructor, typeof(EntityMonoBehaviour), typeof(World))]
        [HarmonyPostfix]
        public static void EquipmentHandler(EquipmentHandler __instance, EntityMonoBehaviour entityMonoBehaviour, World world) {
            equipmentHandler = __instance;
            presetIndex = EntityUtility.GetComponentData<ActiveEquipmentPresetCD>(entityMonoBehaviour.entity, world).Value;
        }

        [BurstDiscard]
        public static void UpdateEquipment() {
            Debug.Log("DEBUG 1");
            
            equipmentHandler.UpdateEquipmentPreset(presetIndex);
            
            Debug.Log("DEBUG 2");
        }
    }
}