using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Unity.Template.VR
{
    public class CustomRotationBinder : AnimationJobBinder<CustomRotationJob, CustomRotationData>
    {
        public override CustomRotationJob Create(Animator animator, ref CustomRotationData data, Component component)
        {
            return new CustomRotationJob()
            {
                constrained = ReadWriteTransformHandle.Bind(animator, data.constrainedObj),
                source = ReadWriteTransformHandle.Bind(animator, data.sourceObj),
            };
        }

        public override void Destroy(CustomRotationJob job)
        {
        }
    }
}
