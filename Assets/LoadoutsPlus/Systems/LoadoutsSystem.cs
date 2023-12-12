using LoadoutsPlus.Patches;
using Unity.Entities;
using UnityEngine;

namespace StatsTracker.Systems {
    [UpdateInGroup(typeof(RunSimulationSystemGroup))]
    public partial class LoadoutsSystem : PugSimulationSystemBase {
        public static readonly int CustomSlotsStartPosition = 256;
        public static readonly int SlotsPerLoadout = 7;
        public static readonly int DefaultLoadoutsAmount = 3;
        public static readonly int ExtraLoadoutsAmount = 5;

        protected override void OnUpdate() {
            Entities.ForEach((ref DynamicBuffer<EquipmentPresetsBuffer> presetBuffer) => {
                int totalLoadoutsAmount = DefaultLoadoutsAmount + ExtraLoadoutsAmount;
            
                if (presetBuffer.Length >= totalLoadoutsAmount) {
                    return;
                }
            
                int loadoutsDelta = totalLoadoutsAmount - presetBuffer.Length;
            
                Debug.Log($"Adding {loadoutsDelta} loadouts to the presets buffer...");

                int originalLength = presetBuffer.Length;
                for (int i = 0; i < loadoutsDelta; i++) {
                    int startSlotIndex = CustomSlotsStartPosition + i * SlotsPerLoadout;
                
                    presetBuffer.Add(new EquipmentPresetsBuffer {
                        equipment = new EquipmentCD {
                            helmSlotIndex = startSlotIndex + 0,
                            necklaceSlotIndex = startSlotIndex + 1,
                            breastSlotIndex = startSlotIndex + 2,
                            pantsSlotIndex = startSlotIndex + 3,
                            ring1SlotIndex = startSlotIndex + 4,
                            ring2SlotIndex = startSlotIndex + 5,
                            offHandIndex = startSlotIndex + 6,
                            bagIndex = 58,
                            petIndex = 83,
                            lanternIndex = 84,
                        }
                    });
                }
            
                Debug.Log($"Finished adding {loadoutsDelta} loadouts to the presets buffer ({originalLength} -> {presetBuffer.Length}).");
            }).Schedule();
            
            Entities.ForEach((ref DynamicBuffer<ContainedObjectsBuffer> inventoryBuffer) => {
                if (!IsPlayerInventory(inventoryBuffer)) {
                    return;
                }

                int totalInventorySlots = CustomSlotsStartPosition + ExtraLoadoutsAmount * SlotsPerLoadout;
            
                if (inventoryBuffer.Length >= totalInventorySlots) {
                    return;
                }
            
                int slotsDelta = totalInventorySlots - inventoryBuffer.Length;
            
                Debug.Log($"Adding {slotsDelta} slots to the inventory buffer...");
            
                int originalLength = inventoryBuffer.Length;
                for (int i = 0; i < slotsDelta; i++) {
                    inventoryBuffer.Add(new ContainedObjectsBuffer {
                        objectData = new ObjectDataCD {
                            objectID = ObjectID.None
                        }
                    });
                }
                
                EquipmentHandlerPatch.UpdateEquipment();
            
                Debug.Log($"Finished adding {slotsDelta} slots to the inventory buffer ({originalLength} -> {inventoryBuffer.Length}).");
            }).Schedule();
        }
        
        private static bool IsPlayerInventory(DynamicBuffer<ContainedObjectsBuffer> inventoryBuffer) {
            return inventoryBuffer.Length >= 86;
        }
    }
}