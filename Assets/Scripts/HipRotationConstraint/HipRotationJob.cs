using Unity.Burst;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

[BurstCompile]
public struct HipRotationJob : IWeightedAnimationJob
{
    public ReadWriteTransformHandle hipBone;
    public ReadWriteTransformHandle headTarget;
    public ReadWriteTransformHandle leftHandTarget;
    public ReadWriteTransformHandle rightHandTarget;
    public float yRotationOffset;
    public FloatProperty jobWeight { get; set; }

    public void ProcessRootMotion(AnimationStream stream)
    {
    }

    public void ProcessAnimation(AnimationStream stream)
    {
        var w = jobWeight.Get(stream);
        if (w > 0f)
        {
            var constrainedRot = hipBone.GetRotation(stream);
            // var sourceRot = headTarget.GetRotation(stream);
            //
            // var directionVector = sourceRot * Vector3.forward;
            // var direction = Vector3.ProjectOnPlane(directionVector, Vector3.up);
            // var rotation = Quaternion.LookRotation(direction);
            // if (Mathf.Abs(rotation.eulerAngles.y) > yRotationOffset)
            // {
            //     hipBone.SetRotation(
            //         stream,
            //         Quaternion.Lerp(
            //             constrainedRot,
            //             Quaternion.LookRotation(direction),
            //             w)
            //     );    
            // }

            var headLeftHandVector = leftHandTarget.GetPosition(stream) - headTarget.GetPosition(stream);
            var headRightHandVector = rightHandTarget.GetPosition(stream) - headTarget.GetPosition(stream);

            var normal = Vector3.Cross(headLeftHandVector, headRightHandVector);
            var normalOnPlane = Vector3.ProjectOnPlane(normal, Vector3.up).normalized;

            var headForward = headTarget.GetRotation(stream) * Vector3.forward;
            var headForwardOnPlane = Vector3.ProjectOnPlane(headForward, Vector3.up).normalized;

            var angle = Vector3.Angle(normalOnPlane , headForwardOnPlane);

            hipBone.SetRotation(
                stream,
                Quaternion.Lerp(
                    constrainedRot,
                    Quaternion.LookRotation(normalOnPlane.normalized),
                    w)
            );
        }
    }


}
