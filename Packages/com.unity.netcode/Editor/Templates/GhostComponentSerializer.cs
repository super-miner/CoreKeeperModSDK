// THIS FILE IS AUTO-GENERATED BY NETCODE PACKAGE SOURCE GENERATORS. DO NOT DELETE, MOVE, COPY, MODIFY, OR COMMIT THIS FILE.
// TO MAKE CHANGES TO THE SERIALIZATION OF A TYPE, REFER TO THE MANUAL.
#region __GHOST_COMPONENT_IS_BUFFER__
#define COMPONENT_IS_BUFFER
#endregion
#region __GHOST_COMPONENT_HAS_FIELDS__
#define COMPONENT_HAS_GHOST_FIELDS
#endregion

using System;
using System.Diagnostics;
using AOT;
using Unity.Burst;
using Unity.NetCode.LowLevel.Unsafe;
using Unity.Collections.LowLevel.Unsafe;
#region __GHOST_USING_STATEMENT__
using __GHOST_USING__;
#endregion

#region __GHOST_END_HEADER__
#endregion
namespace __GHOST_NAMESPACE__
{
    [System.Runtime.CompilerServices.CompilerGenerated]
    [GhostSerializer(typeof(__GHOST_COMPONENT_TYPE__), __GHOST_VARIANT_HASH__)]
    [BurstCompile]
    internal struct __GHOST_NAME__GhostComponentSerializer
    {
        public static GhostComponentSerializer.State GetState(ref SystemState state)
        {
            // This needs to be lazy initialized because otherwise there is a depenency on the static initialization order which breaks il2cpp builds, due to TypeManager not being initialized yet.
            // Also, Burst function pointer compilation can take a while.
            if (!s_StateInitialized)
            {
                s_State = new GhostComponentSerializer.State
                {
                    GhostFieldsHash = __GHOST_FIELD_HASH__,
                    ComponentType = ComponentType.ReadWrite<__GHOST_COMPONENT_TYPE__>(),
                    ComponentSize = UnsafeUtility.SizeOf<__GHOST_COMPONENT_TYPE__>(),
                    SnapshotSize = UnsafeUtility.SizeOf<Snapshot>(),
                    ChangeMaskBits = ChangeMaskBits,
                    PrefabType = __GHOST_PREFAB_TYPE__,
                    SendMask = __GHOST_SEND_MASK__,
                    SendToOwner = __GHOST_SEND_OWNER__,
                    VariantHash = __GHOST_VARIANT_HASH__,
                    SerializationStrategyIndex = -1,
                    SerializesEnabledBit = __GHOST_SERIALIZES_ENABLED_BIT__,
#if UNITY_EDITOR || NETCODE_DEBUG
                    ProfilerMarker = new Unity.Profiling.ProfilerMarker("__GHOST_COMPONENT_TYPE__")
#endif
                };

                // Optimization: Creating burst functions is expensive.
                // We don't need to do it in literally any other words as they're never called.
                if ((state.WorldUnmanaged.Flags & WorldFlags.GameServer) == WorldFlags.GameServer
                    || (state.WorldUnmanaged.Flags & WorldFlags.GameClient) == WorldFlags.GameClient
                    || (state.WorldUnmanaged.Flags & WorldFlags.GameThinClient) == WorldFlags.GameServer)
                {
#if UNITY_EDITOR || NETCODE_DEBUG
                    s_State.ProfilerMarker.Begin();
                    var innerMarker = new Unity.Profiling.ProfilerMarker("__GHOST_NAME__");
                    innerMarker.Begin();
#endif

#if COMPONENT_IS_BUFFER
                    s_State.PostSerializeBuffer =
                        new PortableFunctionPointer<GhostComponentSerializer.PostSerializeBufferDelegate>(PostSerializeBuffer);
                    s_State.SerializeBuffer =
                        new PortableFunctionPointer<GhostComponentSerializer.SerializeBufferDelegate>(SerializeBuffer);
#else
                    s_State.PostSerialize =
                        new PortableFunctionPointer<GhostComponentSerializer.PostSerializeDelegate>(PostSerialize);
                    s_State.Serialize =
                        new PortableFunctionPointer<GhostComponentSerializer.SerializeDelegate>(Serialize);
                    s_State.SerializeChild =
                        new PortableFunctionPointer<GhostComponentSerializer.SerializeChildDelegate>(SerializeChild);
#endif
                    s_State.CopyToSnapshot =
                        new PortableFunctionPointer<GhostComponentSerializer.CopyToFromSnapshotDelegate>(CopyToSnapshot);
                    s_State.CopyFromSnapshot =
                        new PortableFunctionPointer<GhostComponentSerializer.CopyToFromSnapshotDelegate>(CopyFromSnapshot);
                    s_State.RestoreFromBackup =
                        new PortableFunctionPointer<GhostComponentSerializer.RestoreFromBackupDelegate>(RestoreFromBackup);
                    s_State.PredictDelta = new PortableFunctionPointer<GhostComponentSerializer.PredictDeltaDelegate>(PredictDelta);
                    s_State.Deserialize = new PortableFunctionPointer<GhostComponentSerializer.DeserializeDelegate>(Deserialize);
#if UNITY_EDITOR || NETCODE_DEBUG
                    s_State.ReportPredictionErrors = new PortableFunctionPointer<GhostComponentSerializer.ReportPredictionErrorsDelegate>(ReportPredictionErrors);
#endif
                    s_StateInitialized = true;

#if UNITY_EDITOR || NETCODE_DEBUG
                    innerMarker.End();
                    s_State.ProfilerMarker.End();
#endif
                }

                // UnsafeUtility.SizeOf<T> reports 1 with zero-sized components.
                if (s_State.ComponentType.IsZeroSized)
                {
                    s_State.ComponentSize = 0;
                }
#region __GHOST_HAS_NO_GHOST_FIELDS__
                s_State.SnapshotSize = 0;
#endregion
                //TODO: DOTS-7926 we should understand why we have in some cases a StackOverflowException.
                //UNCOMMENT THIS LINE TO DEBUG IF A BIG COMPONENT MAY BE CAUSING A STACK OVERFLOW
                // const int maxSizeToAvoidStackOverflow = 4_500;
                // if (s_State.ComponentSize > maxSizeToAvoidStackOverflow)
                // {
                //     UnityEngine.Debug.LogWarning($"The type '{s_State.ComponentType}' is very large ({s_State.ComponentSize} bytes)! There is a risk of StackOverflowExceptions in the Serializers at roughly {maxSizeToAvoidStackOverflow} bytes! Remove large fields.");
                // }
#if UNITY_EDITOR || NETCODE_DEBUG
                s_State.NumPredictionErrors = GetPredictionErrorNames(ref s_State.PredictionErrorNames);
                #endif
            }
            return s_State;
        }
        private static bool s_StateInitialized;
        private static GhostComponentSerializer.State s_State;
        public struct Snapshot
        {
            #region __GHOST_FIELD__
            #endregion
        }
        public const int ChangeMaskBits = __GHOST_CHANGE_MASK_BITS__;

#if COMPONENT_IS_BUFFER
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        private static void CheckDynamicDataRange(int dynamicSnapshotDataOffset, int maskSize, int len, int dynamicDataSize, int dynamicSnapshotMaxOffset)
        {
            if ((dynamicSnapshotDataOffset + maskSize + len*dynamicDataSize) > dynamicSnapshotMaxOffset)
                throw new InvalidOperationException("writing snapshot dyanmicdata outside of memory history buffer memory boundary");
        }
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        private static void CheckDynamicMaskOffset(int offset, int sizeInBytes)
        {
            if (offset > sizeInBytes*8)
                throw new InvalidOperationException("writing dynamic mask bits outside out of bound");
        }
        private static void SerializeOneBuffer(int ent,
            IntPtr snapshotData, int snapshotOffset, int snapshotStride, int maskOffsetInBits, IntPtr baselines,
            ref DataStreamWriter writer, ref StreamCompressionModel compressionModel, IntPtr entityStartBit,
            IntPtr snapshotDynamicDataPtr, IntPtr dynamicSizePerEntity, int dynamicSnapshotMaxOffset,
            int len, ref int dynamicSnapshotDataOffset, int dynamicDataSize, int maskSize)
        {
    #if COMPONENT_HAS_GHOST_FIELDS
            int PtrSize = UnsafeUtility.SizeOf<IntPtr>();
            const int IntSize = 4;
            const int BaselinesPerEntity = 4;
            ref var startuint = ref GhostComponentSerializer.TypeCast<int>(entityStartBit, IntSize*2*ent);
            startuint = writer.Length/IntSize;

            int baseLen = 0;
            int baseOffset = 0;
            var baseline0Ptr = GhostComponentSerializer.TypeCast<IntPtr>(baselines, PtrSize*ent*BaselinesPerEntity);
            if (baseline0Ptr != IntPtr.Zero)
            {
                baseLen = (int)GhostComponentSerializer.TypeCast<uint>(baseline0Ptr, snapshotOffset);
                baseOffset = (int)GhostComponentSerializer.TypeCast<uint>(baseline0Ptr, snapshotOffset+IntSize);
            }
            var baselineDynamicDataPtr = GhostComponentSerializer.TypeCast<IntPtr>(baselines, PtrSize*(ent*BaselinesPerEntity+3));

            // Calculate change masks for dynamic data
            var dynamicMaskUints = GhostComponentSerializer.ChangeMaskArraySizeInUInts((int)(ChangeMaskBits * len));
            var dynamicMaskBitsPtr = snapshotDynamicDataPtr + dynamicSnapshotDataOffset;
            var dynamicMaskOffset = 0;
            var offset = dynamicSnapshotDataOffset;
            var bOffset = baseOffset;
            if (len == baseLen)
            {
                for (int j = 0; j < len; ++j)
                {
                    CheckDynamicMaskOffset(dynamicMaskOffset, maskSize);
                    CalculateChangeMask(ref GhostComponentSerializer.TypeCast<Snapshot>(snapshotDynamicDataPtr, maskSize + offset),
                        GhostComponentSerializer.TypeCast<Snapshot>(baselineDynamicDataPtr, maskSize + bOffset),
                        dynamicMaskBitsPtr, dynamicMaskOffset);
                    offset += dynamicDataSize;
                    bOffset += dynamicDataSize;
                    dynamicMaskOffset += ChangeMaskBits;
                }
                // Calculate any change mask and set the dynamic snapshot mask
                uint anyChangeMask = 0;

                //Cleanup the remaining bits for the changemasks
                var changeMaskLenInBits = ChangeMaskBits * len;
                var remaining = (ChangeMaskBits * len)&31;
                if(remaining > 0)
                    GhostComponentSerializer.CopyToChangeMask(snapshotDynamicDataPtr + dynamicSnapshotDataOffset, 0, changeMaskLenInBits, 32-remaining);
                for (int mi = 0; mi < dynamicMaskUints; ++mi)
                {
                    uint changeMaskUint = GhostComponentSerializer.TypeCast<uint>(snapshotDynamicDataPtr + dynamicSnapshotDataOffset, mi*IntSize);
                    anyChangeMask |= (changeMaskUint!=0)?1u:0;
                }
                GhostComponentSerializer.CopyToChangeMask(snapshotData + IntSize + snapshotStride*ent, anyChangeMask, maskOffsetInBits, 2);
                if (anyChangeMask != 0)
                {
                    // Write the bits to the data stream
                    for (int mi = 0; mi < dynamicMaskUints; ++mi)
                    {
                        uint changeMaskUint = GhostComponentSerializer.TypeCast<uint>(snapshotDynamicDataPtr + dynamicSnapshotDataOffset, mi*IntSize);
                        uint changeBaseMaskUint = GhostComponentSerializer.TypeCast<uint>(baselineDynamicDataPtr + baseOffset, mi*IntSize);
                        writer.WritePackedUIntDelta(changeMaskUint, changeBaseMaskUint, compressionModel);
                    }
                }
            }
            else
            {
                // Clear the dynamic change mask to all 1
                var remaining = ChangeMaskBits * len;
                while (remaining > 32)
                {
                    GhostComponentSerializer.CopyToChangeMask(dynamicMaskBitsPtr, ~0u, dynamicMaskOffset, 32);
                    dynamicMaskOffset += 32;
                    remaining -= 32;
                }
                if (remaining > 0)
                    GhostComponentSerializer.CopyToChangeMask(dynamicMaskBitsPtr, (1u<<remaining)-1, dynamicMaskOffset, remaining);
                // FIXME: setting the bits as above is more correct, but requires changes to the receive system making it incompatible with the v1 serializer
                for (int j = 0; j < maskSize; ++j)
                    GhostComponentSerializer.TypeCast<byte>(dynamicMaskBitsPtr, j) = 0xff;
                //UnsafeUtility.MemSet(dynamicMaskBitsPtr, 0xFF, maskSize);
                // Set the dynamic snapshot mask
                GhostComponentSerializer.CopyToChangeMask(snapshotData + IntSize + snapshotStride*ent, 3, maskOffsetInBits, 2);

                baselineDynamicDataPtr = IntPtr.Zero;
                writer.WritePackedUIntDelta((uint)len, (uint)baseLen, compressionModel);
            }
            //Serialize the elements contents
            dynamicMaskOffset = 0;
            offset = dynamicSnapshotDataOffset;
            bOffset = baseOffset;
            Snapshot baselineData = default;
            for (int j = 0; j < len; ++j)
            {
                if (baselineDynamicDataPtr != IntPtr.Zero)
                    baselineData = GhostComponentSerializer.TypeCast<Snapshot>(baselineDynamicDataPtr, maskSize + bOffset);
                SerializeSnapshot(GhostComponentSerializer.TypeCast<Snapshot>(snapshotDynamicDataPtr, maskSize + offset),
                    baselineData,
                    ref writer,
                    ref compressionModel,
                    dynamicMaskBitsPtr, dynamicMaskOffset);
                offset += dynamicDataSize;
                bOffset += dynamicDataSize;
                dynamicMaskOffset += ChangeMaskBits;
            }

            var dynamicSize = GhostComponentSerializer.SnapshotSizeAligned(maskSize + dynamicDataSize * len);
            GhostComponentSerializer.TypeCast<int>(dynamicSizePerEntity, ent*IntSize) += dynamicSize;
            dynamicSnapshotDataOffset += dynamicSize;

            ref var sbit = ref GhostComponentSerializer.TypeCast<int>(entityStartBit, IntSize*2*ent+IntSize);
            sbit = writer.LengthInBits - startuint*32;
            var missing = 32-writer.LengthInBits&31;
            if (missing < 32)
                writer.WriteRawBits(0, missing);
    #endif
        }
        [BurstCompile(DisableDirectCall = true)]
        [MonoPInvokeCallback(typeof(GhostComponentSerializer.PostSerializeBufferDelegate))]
        public static void PostSerializeBuffer(IntPtr snapshotData, int snapshotOffset, int snapshotStride, int maskOffsetInBits, int count, IntPtr baselines, ref DataStreamWriter writer, ref StreamCompressionModel compressionModel, IntPtr entityStartBit, IntPtr snapshotDynamicDataPtr, IntPtr dynamicSizePerEntity, int dynamicSnapshotMaxOffset)
        {
    #if COMPONENT_HAS_GHOST_FIELDS
            int dynamicDataSize = UnsafeUtility.SizeOf<Snapshot>();
            for (int i = 0; i < count; ++i)
            {
                // Get the elements count and the buffer content offset inside the dynamic data history buffer from the pre-serialized snapshot
                int len = GhostComponentSerializer.TypeCast<int>(snapshotData + snapshotStride*i, snapshotOffset);
                int dynamicSnapshotDataOffset = GhostComponentSerializer.TypeCast<int>(snapshotData + snapshotStride*i, snapshotOffset+4);
                var maskSize = SnapshotDynamicBuffersHelper.GetDynamicDataChangeMaskSize(ChangeMaskBits, len);
                CheckDynamicDataRange(dynamicSnapshotDataOffset, maskSize, len, dynamicDataSize, dynamicSnapshotMaxOffset);
                SerializeOneBuffer(i, snapshotData, snapshotOffset, snapshotStride, maskOffsetInBits, baselines, ref writer, ref compressionModel, entityStartBit, snapshotDynamicDataPtr, dynamicSizePerEntity, dynamicSnapshotMaxOffset, len, ref dynamicSnapshotDataOffset, dynamicDataSize, maskSize);
            }
    #endif
        }
        [BurstCompile(DisableDirectCall = true)]
        [MonoPInvokeCallback(typeof(GhostComponentSerializer.SerializeBufferDelegate))]
        public static void SerializeBuffer(IntPtr stateData,
            IntPtr snapshotData, int snapshotOffset, int snapshotStride, int maskOffsetInBits,
            IntPtr componentData, IntPtr componentDataLen, int count, IntPtr baselines,
            ref DataStreamWriter writer, ref StreamCompressionModel compressionModel,
            IntPtr entityStartBit, IntPtr snapshotDynamicDataPtr, ref int dynamicSnapshotDataOffset,
            IntPtr dynamicSizePerEntity, int dynamicSnapshotMaxOffset)
        {
    #if COMPONENT_HAS_GHOST_FIELDS
            int dynamicDataSize = UnsafeUtility.SizeOf<Snapshot>();
            for (int i = 0; i < count; ++i)
            {
                int len = GhostComponentSerializer.TypeCast<int>(componentDataLen, i*4);
                //Set the elements count and the buffer content offset inside the dynamic data history buffer
                GhostComponentSerializer.TypeCast<uint>(snapshotData + snapshotStride*i, snapshotOffset) = (uint)len;
                GhostComponentSerializer.TypeCast<uint>(snapshotData + snapshotStride*i, snapshotOffset+4) = (uint)dynamicSnapshotDataOffset;

                var maskSize = SnapshotDynamicBuffersHelper.GetDynamicDataChangeMaskSize(ChangeMaskBits, len);
                CheckDynamicDataRange(dynamicSnapshotDataOffset, maskSize, len, dynamicDataSize, dynamicSnapshotMaxOffset);

                if (len > 0)
                {
                    //Copy the buffer contents
                    IntPtr curCompData = GhostComponentSerializer.TypeCast<IntPtr>(componentData, UnsafeUtility.SizeOf<IntPtr>()*i);
                    CopyToSnapshot(stateData, snapshotDynamicDataPtr + maskSize, dynamicSnapshotDataOffset, dynamicDataSize, curCompData, UnsafeUtility.SizeOf<__GHOST_COMPONENT_TYPE__>(), len);
                }
                SerializeOneBuffer(i, snapshotData, snapshotOffset, snapshotStride, maskOffsetInBits, baselines, ref writer, ref compressionModel, entityStartBit, snapshotDynamicDataPtr, dynamicSizePerEntity, dynamicSnapshotMaxOffset, len, ref dynamicSnapshotDataOffset, dynamicDataSize, maskSize);
            }
    #endif
        }
#else
        private static void SerializeOneEntity(int ent,
            IntPtr snapshotData, int snapshotOffset, int snapshotStride, int maskOffsetInBits, IntPtr baselines,
            ref DataStreamWriter writer, ref StreamCompressionModel compressionModel, IntPtr entityStartBit)
        {
    #if COMPONENT_HAS_GHOST_FIELDS
            int PtrSize = UnsafeUtility.SizeOf<IntPtr>();
            const int IntSize = 4;
            const int BaselinesPerEntity = 4;
            ref var startuint = ref GhostComponentSerializer.TypeCast<int>(entityStartBit, IntSize*2*ent);
            startuint = writer.Length/IntSize;

            // Calculate the baseline
            Snapshot baseline = default;
            var baseline0Ptr = GhostComponentSerializer.TypeCast<IntPtr>(baselines, PtrSize*ent*BaselinesPerEntity);
            if (baseline0Ptr != IntPtr.Zero)
            {
                baseline = GhostComponentSerializer.TypeCast<Snapshot>(baseline0Ptr, snapshotOffset);
                var baseline2Ptr = GhostComponentSerializer.TypeCast<IntPtr>(baselines, PtrSize*(ent*BaselinesPerEntity+2));
                if (baseline2Ptr != IntPtr.Zero)
                {
                    var baseline1Ptr = GhostComponentSerializer.TypeCast<IntPtr>(baselines, PtrSize*(ent*BaselinesPerEntity+1));
                    var predictor = new GhostDeltaPredictor(new NetworkTick{SerializedData = GhostComponentSerializer.TypeCast<uint>(snapshotData + snapshotStride*ent)},
                        new NetworkTick{SerializedData = GhostComponentSerializer.TypeCast<uint>(baseline0Ptr)},
                        new NetworkTick{SerializedData = GhostComponentSerializer.TypeCast<uint>(baseline1Ptr)},
                        new NetworkTick{SerializedData = GhostComponentSerializer.TypeCast<uint>(baseline2Ptr)});
                    PredictDelta(GhostComponentSerializer.IntPtrCast(ref baseline), baseline1Ptr+snapshotOffset, baseline2Ptr+snapshotOffset, ref predictor);
                }
            }

            ref Snapshot snapshot =ref GhostComponentSerializer.TypeCast<Snapshot>(snapshotData, snapshotOffset + snapshotStride*ent);
            CalculateChangeMask(ref snapshot, baseline, snapshotData+IntSize + snapshotStride*ent, maskOffsetInBits);

            SerializeSnapshot(snapshot, baseline, ref writer, ref compressionModel, snapshotData+IntSize + snapshotStride*ent, maskOffsetInBits);
            ref var sbit = ref GhostComponentSerializer.TypeCast<int>(entityStartBit, IntSize*2*ent+IntSize);
            sbit = writer.LengthInBits - startuint*32;
            var missing = 32-writer.LengthInBits&31;
            if (missing < 32)
                writer.WriteRawBits(0, missing);
    #else

            // TODO: Move this outside code-gen, as we really dont need to do this here!
            const int IntSize = 4;
            ref var startuint = ref GhostComponentSerializer.TypeCast<int>(entityStartBit, IntSize*2*ent);
            startuint = writer.Length/IntSize;
            startuint = ref GhostComponentSerializer.TypeCast<int>(entityStartBit, IntSize*2*ent+IntSize);
            startuint = 0;
    #endif
        }
        [BurstCompile(DisableDirectCall = true)]
        [MonoPInvokeCallback(typeof(GhostComponentSerializer.PostSerializeDelegate))]
        public static void PostSerialize(IntPtr snapshotData, int snapshotOffset, int snapshotStride, int maskOffsetInBits, int count, IntPtr baselines, ref DataStreamWriter writer, ref StreamCompressionModel compressionModel, IntPtr entityStartBit)
        {
    #if COMPONENT_HAS_GHOST_FIELDS
            for (int i = 0; i < count; ++i)
            {
                SerializeOneEntity(i, snapshotData, snapshotOffset, snapshotStride, maskOffsetInBits, baselines, ref writer, ref compressionModel, entityStartBit);
            }
    #else
            // TODO: Move this outside code-gen, as we really dont need to do this here!
            for (int i = 0; i < count; ++i)
            {
                const int IntSize = 4;
                ref var startuint = ref GhostComponentSerializer.TypeCast<int>(entityStartBit, IntSize*2*i);
                startuint = writer.Length/IntSize;
                startuint = ref GhostComponentSerializer.TypeCast<int>(entityStartBit, IntSize*2*i+IntSize);
                startuint = 0;
            }
    #endif
        }
        [BurstCompile(DisableDirectCall = true)]
        [MonoPInvokeCallback(typeof(GhostComponentSerializer.SerializeDelegate))]
        public static void Serialize(IntPtr stateData,
            IntPtr snapshotData, int snapshotOffset, int snapshotStride, int maskOffsetInBits,
            IntPtr componentData, int componentStride, int count, IntPtr baselines,
            ref DataStreamWriter writer, ref StreamCompressionModel compressionModel, IntPtr entityStartBit)
        {
    #if COMPONENT_HAS_GHOST_FIELDS
            ref var serializerState = ref GhostComponentSerializer.TypeCast<GhostSerializerState>(stateData, 0);
            for (int i = 0; i < count; ++i)
            {
                if (componentData != IntPtr.Zero)
                {
                    ref var snapshot = ref GhostComponentSerializer.TypeCast<Snapshot>(snapshotData, snapshotOffset + snapshotStride*i);
                    ref var component = ref GhostComponentSerializer.TypeCast<__GHOST_COMPONENT_TYPE__>(componentData, componentStride*i);
                    CopyToSnapshot(serializerState, ref snapshot, component);
                }
                else
                    GhostComponentSerializer.TypeCast<Snapshot>(snapshotData+snapshotStride*i, snapshotOffset) = default;

                SerializeOneEntity(i, snapshotData, snapshotOffset, snapshotStride, maskOffsetInBits, baselines, ref writer, ref compressionModel, entityStartBit);
            }
    #else
            // TODO: Move this outside code-gen, as we really dont need to do this here!
            for (int i = 0; i < count; ++i)
            {
                const int IntSize = 4;
                ref var startuint = ref GhostComponentSerializer.TypeCast<int>(entityStartBit, IntSize*2*i);
                startuint = writer.Length/IntSize;
                startuint = ref GhostComponentSerializer.TypeCast<int>(entityStartBit, IntSize*2*i+IntSize);
                startuint = 0;
            }
    #endif
        }
        [BurstCompile(DisableDirectCall = true)]
        [MonoPInvokeCallback(typeof(GhostComponentSerializer.SerializeChildDelegate))]
        public static void SerializeChild(IntPtr stateData,
            IntPtr snapshotData, int snapshotOffset, int snapshotStride, int maskOffsetInBits,
            IntPtr componentData, int count, IntPtr baselines,
            ref DataStreamWriter writer, ref StreamCompressionModel compressionModel, IntPtr entityStartBit)
        {
    #if COMPONENT_HAS_GHOST_FIELDS
            ref var serializerState = ref GhostComponentSerializer.TypeCast<GhostSerializerState>(stateData, 0);
            for (int i = 0; i < count; ++i)
            {
                IntPtr curCompData = GhostComponentSerializer.TypeCast<IntPtr>(componentData, UnsafeUtility.SizeOf<IntPtr>()*i);
                if (curCompData != IntPtr.Zero)
                {
                    ref var snapshot = ref GhostComponentSerializer.TypeCast<Snapshot>(snapshotData, snapshotOffset + snapshotStride*i);
                    ref var component = ref GhostComponentSerializer.TypeCast<__GHOST_COMPONENT_TYPE__>(curCompData);
                    CopyToSnapshot(serializerState, ref snapshot, component);
                }
                else
                    GhostComponentSerializer.TypeCast<Snapshot>(snapshotData+snapshotStride*i, snapshotOffset) = default;

                SerializeOneEntity(i, snapshotData, snapshotOffset, snapshotStride, maskOffsetInBits, baselines, ref writer, ref compressionModel, entityStartBit);
            }
    #else
            // TODO: Move this outside code-gen, as we really dont need to do this here!
            for (int i = 0; i < count; ++i)
            {
                const int IntSize = 4;
                ref var startuint = ref GhostComponentSerializer.TypeCast<int>(entityStartBit, IntSize*2*i);
                startuint = writer.Length/IntSize;
            startuint = ref GhostComponentSerializer.TypeCast<int>(entityStartBit, IntSize*2*i+IntSize);
            startuint = 0;
            }
    #endif
        }
#endif

        private static void CopyToSnapshot(in GhostSerializerState serializerState, ref Snapshot snapshot, in __GHOST_COMPONENT_TYPE__ component)
        {
#if COMPONENT_HAS_GHOST_FIELDS
            #region __GHOST_COPY_TO_SNAPSHOT__
            #endregion
#endif
        }
        [BurstCompile(DisableDirectCall = true)]
        [MonoPInvokeCallback(typeof(GhostComponentSerializer.CopyToFromSnapshotDelegate))]
        public static void CopyToSnapshot(IntPtr stateData, IntPtr snapshotData, int snapshotOffset, int snapshotStride, IntPtr componentData, int componentStride, int count)
        {
#if COMPONENT_HAS_GHOST_FIELDS
            for (int i = 0; i < count; ++i)
            {
                ref var snapshot = ref GhostComponentSerializer.TypeCast<Snapshot>(snapshotData, snapshotOffset + snapshotStride*i);
                ref var component = ref GhostComponentSerializer.TypeCast<__GHOST_COMPONENT_TYPE__>(componentData, componentStride*i);
                ref var serializerState = ref GhostComponentSerializer.TypeCast<GhostSerializerState>(stateData, 0);
                CopyToSnapshot(serializerState, ref snapshot, component);
            }
#endif
        }
        [BurstCompile(DisableDirectCall = true)]
        [MonoPInvokeCallback(typeof(GhostComponentSerializer.CopyToFromSnapshotDelegate))]
        public static void CopyFromSnapshot(IntPtr stateData, IntPtr snapshotData, int snapshotOffset, int snapshotStride, IntPtr componentData, int componentStride, int count)
        {
#if COMPONENT_HAS_GHOST_FIELDS
            for (int i = 0; i < count; ++i)
            {
                var deserializerState = GhostComponentSerializer.TypeCast<GhostDeserializerState>(stateData, 0);
                #region __GHOST_COPY_FROM_COMPONENT__
                ref var snapshotInterpolationData = ref GhostComponentSerializer.TypeCast<SnapshotData.DataAtTick>(snapshotData, snapshotStride*i);
                ref var snapshotBefore = ref GhostComponentSerializer.TypeCast<Snapshot>(snapshotInterpolationData.SnapshotBefore, snapshotOffset);
                ref var snapshotAfter = ref GhostComponentSerializer.TypeCast<Snapshot>(snapshotInterpolationData.SnapshotAfter, snapshotOffset);
                //Compute the required owner mask for the components and buffers by retrievieng the ghost owner id from the data for the current tick.
                if (snapshotInterpolationData.GhostOwner > 0)
                {
                    var requiredOwnerMask = snapshotInterpolationData.GhostOwner == deserializerState.GhostOwner
                        ? SendToOwnerType.SendToOwner
                        : SendToOwnerType.SendToNonOwner;
                    if ((deserializerState.SendToOwner & requiredOwnerMask) == 0)
                        continue;
                }
                #endregion
                #region __GHOST_COPY_FROM_BUFFER__
                //For buffers the function iterate over the element in the buffers not entities.
                ref var snapshotInterpolationData = ref GhostComponentSerializer.TypeCast<SnapshotData.DataAtTick>(snapshotData);
                ref var snapshotBefore = ref GhostComponentSerializer.TypeCast<Snapshot>(snapshotInterpolationData.SnapshotBefore, snapshotOffset + snapshotStride*i);
                ref var snapshotAfter = ref snapshotBefore;
                #endregion
                #region __COPY_FROM_SNAPSHOT_SETUP__
                #endregion
                deserializerState.SnapshotTick = snapshotInterpolationData.Tick;
                float snapshotInterpolationFactorRaw = snapshotInterpolationData.InterpolationFactor;
                float snapshotInterpolationFactor = snapshotInterpolationFactorRaw;
                ref var component = ref GhostComponentSerializer.TypeCast<__GHOST_COMPONENT_TYPE__>(componentData, componentStride*i);
                #region __GHOST_COPY_FROM_SNAPSHOT__
                #endregion

                #region __GHOST_COPY_FROM_SNAPSHOT_DISABLE_EXTRAPOLATION__
                snapshotInterpolationFactor = math.max(snapshotInterpolationFactorRaw, 0);
                #endregion
                #region __GHOST_COPY_FROM_SNAPSHOT_ENABLE_EXTRAPOLATION__
                snapshotInterpolationFactor = snapshotInterpolationFactorRaw;
                #endregion
                #region __GHOST_COPY_FROM_SNAPSHOT_INTERPOLATE_CLAMP_MAX__
                if (__GHOST_FIELD_NAME___DistSq > __GHOST_MAX_INTERPOLATION_DISTSQ__)
                    snapshotInterpolationFactor = 0;
                #endregion
            }
#endif
        }


        [BurstCompile(DisableDirectCall = true)]
        [MonoPInvokeCallback(typeof(GhostComponentSerializer.RestoreFromBackupDelegate))]
        public static void RestoreFromBackup(IntPtr componentData, IntPtr backupData)
        {
#if COMPONENT_HAS_GHOST_FIELDS
            ref var component = ref GhostComponentSerializer.TypeCast<__GHOST_COMPONENT_TYPE__>(componentData, 0);
            ref var backup = ref GhostComponentSerializer.TypeCast<__GHOST_COMPONENT_TYPE__>(backupData, 0);
            #region __GHOST_RESTORE_FROM_BACKUP__
            #endregion
#endif
        }

        [BurstCompile(DisableDirectCall = true)]
        [MonoPInvokeCallback(typeof(GhostComponentSerializer.PredictDeltaDelegate))]
        public static void PredictDelta(IntPtr snapshotData, IntPtr baseline1Data, IntPtr baseline2Data, ref GhostDeltaPredictor predictor)
        {
#if COMPONENT_HAS_GHOST_FIELDS
            ref var snapshot = ref GhostComponentSerializer.TypeCast<Snapshot>(snapshotData);
            ref var baseline1 = ref GhostComponentSerializer.TypeCast<Snapshot>(baseline1Data);
            ref var baseline2 = ref GhostComponentSerializer.TypeCast<Snapshot>(baseline2Data);
            #region __GHOST_PREDICT__
            #endregion
#endif
        }
        private static void CalculateChangeMask(ref Snapshot snapshot, in Snapshot baseline, IntPtr bits, int startOffset)
        {
#if COMPONENT_HAS_GHOST_FIELDS
            uint changeMask;
            #region __GHOST_CALCULATE_CHANGE_MASK__
            #endregion
            #region __GHOST_FLUSH_COMPONENT_CHANGE_MASK__
            GhostComponentSerializer.CopyToChangeMask(bits, changeMask, startOffset, 32);
            startOffset += 32;
            #endregion
            #region __GHOST_FLUSH_FINAL_COMPONENT_CHANGE_MASK__
            GhostComponentSerializer.CopyToChangeMask(bits, changeMask, startOffset, __GHOST_CHANGE_MASK_BITS__);
            #endregion
#endif
        }
        private static void SerializeSnapshot(in Snapshot snapshot, in Snapshot baseline, ref DataStreamWriter writer, ref StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset)
        {
#if COMPONENT_HAS_GHOST_FIELDS
            uint changeMask = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, ChangeMaskBits);
            #region __GHOST_WRITE__
            #endregion
            #region __GHOST_REFRESH_CHANGE_MASK__
            changeMask = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset + __GHOST_CHANGE_MASK_BITS__, ChangeMaskBits - __GHOST_CHANGE_MASK_BITS__);
            #endregion
#endif
        }
        [BurstCompile(DisableDirectCall = true)]
        [MonoPInvokeCallback(typeof(GhostComponentSerializer.DeserializeDelegate))]
        public static void Deserialize(IntPtr snapshotData, IntPtr baselineData, ref DataStreamReader reader, ref StreamCompressionModel compressionModel, IntPtr changeMaskData, int startOffset)
        {
#if COMPONENT_HAS_GHOST_FIELDS
            ref var snapshot = ref GhostComponentSerializer.TypeCast<Snapshot>(snapshotData);
            ref var baseline = ref GhostComponentSerializer.TypeCast<Snapshot>(baselineData);
            uint changeMask = GhostComponentSerializer.CopyFromChangeMask(changeMaskData, startOffset, ChangeMaskBits);
            #region __GHOST_READ__
            #endregion
#endif
        }
        #if UNITY_EDITOR || NETCODE_DEBUG
        [BurstCompile(DisableDirectCall = true)]
        [MonoPInvokeCallback(typeof(GhostComponentSerializer.ReportPredictionErrorsDelegate))]
        public static void ReportPredictionErrors(IntPtr componentData, IntPtr backupData, IntPtr errorsList, int errorsCount)
        {
#if COMPONENT_HAS_GHOST_FIELDS
            #region __GHOST_PREDICTION_ERROR_HEADER__
            ref var component = ref GhostComponentSerializer.TypeCast<__GHOST_COMPONENT_TYPE__>(componentData, 0);
            ref var backup = ref GhostComponentSerializer.TypeCast<__GHOST_COMPONENT_TYPE__>(backupData, 0);
            var errors = GhostComponentSerializer.ConvertToUnsafeList(errorsList, errorsCount);
            int errorIndex = 0;
            #endregion
            #region __GHOST_REPORT_PREDICTION_ERROR__
            #endregion
#endif
        }
        #endif
        #if UNITY_EDITOR || NETCODE_DEBUG
        public static int GetPredictionErrorNames(ref FixedString512Bytes names)
        {
            int nameCount = 0;
            #region __GHOST_GET_PREDICTION_ERROR_NAME__
            #endregion
            return nameCount;
        }
        #endif
    }
}
