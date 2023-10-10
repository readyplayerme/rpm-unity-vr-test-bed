using Unity.Burst;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

[BurstCompile]
public struct HipRotationJob : IWeightedAnimationJob
{
    public ReadWriteTransformHandle constrained;
    public ReadWriteTransformHandle source;
    public FloatProperty jobWeight { get; set; }

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

            var constrainedRotY = Quaternion.Euler(0, constrainedRot.eulerAngles.y, 0);

            var directionVector = sourceRot * Vector3.forward;
            var d = Vector3.ProjectOnPlane(directionVector, Vector3.up);

            constrained.SetRotation(
                stream,
                Quaternion.Lerp(
                    constrainedRot,
                    Quaternion.LookRotation(d),
                    w)
            );
        }
    }


}
