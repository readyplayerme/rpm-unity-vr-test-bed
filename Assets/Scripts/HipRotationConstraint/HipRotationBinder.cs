using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Unity.Template.VR
{
    public class HipRotationBinder : AnimationJobBinder<HipRotationJob, HipRotationData>
    {

        public override HipRotationJob Create(Animator animator, ref HipRotationData data, Component component)
        {
            return new HipRotationJob()
            {
                hipBone = ReadWriteTransformHandle.Bind(animator, data.hipBone),
                headTarget = ReadWriteTransformHandle.Bind(animator, data.headTarget),
                leftHandTarget = ReadWriteTransformHandle.Bind(animator, data.leftHandTarget),
                rightHandTarget = ReadWriteTransformHandle.Bind(animator, data.rightHandTarget),
                yRotationOffset = data.yRotationOffset
            };
        }

        public override void Destroy(HipRotationJob job)
        {
        }
    }
}
