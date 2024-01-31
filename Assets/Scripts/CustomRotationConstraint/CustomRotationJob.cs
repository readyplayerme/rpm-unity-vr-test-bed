using Unity.Burst;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace ReadyPlayerMe.VR
{
    [BurstCompile]
    public struct CustomRotationJob : IWeightedAnimationJob
    {
        public ReadWriteTransformHandle constrained;
        public ReadWriteTransformHandle source;
        public FloatProperty jobWeight { get; set; }

        private Quaternion rotation;

        public void ProcessRootMotion(AnimationStream stream)
        {
        }

        public void ProcessAnimation(AnimationStream stream)
        {
            var w = jobWeight.Get(stream);
            if (w > 0f)
            {
                var constrainedRot = constrained.GetRotation(stream);
                var sourceRot = source.GetRotation(stream);

                var directionVector = sourceRot * Vector3.forward;
                var direction = Vector3.ProjectOnPlane(directionVector, Vector3.up).normalized;

                rotation = Quaternion.LookRotation(direction).normalized;

                constrained.SetRotation(
                    stream,
                    Quaternion.Lerp(
                        constrainedRot,
                        rotation,
                        w)
                );
            }
        }


    }
}
