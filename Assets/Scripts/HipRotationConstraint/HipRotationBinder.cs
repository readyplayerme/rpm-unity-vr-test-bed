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

                constrained = ReadWriteTransformHandle.Bind(animator, data.constrainedObject),
                source = ReadWriteTransformHandle.Bind(animator, data.sourceObject)
            };

        }

        public override void Destroy(HipRotationJob job)
        {
        }
    }
}
