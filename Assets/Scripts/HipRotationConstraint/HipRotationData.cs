using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Unity.Template.VR
{
    [Serializable]
    public struct HipRotationData  : IAnimationJobData
    {
        public Transform hipBone;
        [SyncSceneToStream] public Transform headTarget;

        public Transform leftHandTarget;
        public Transform rightHandTarget;
        
        public float yRotationOffset;
        
        public bool IsValid()
        {
            return !(hipBone == null || headTarget == null || leftHandTarget == null || rightHandTarget == null);
        }

        public void SetDefaultValues()
        {
            hipBone = null;
            headTarget = null;
            leftHandTarget = null;
            rightHandTarget = null;
            yRotationOffset = 0;
        }
    }
}
