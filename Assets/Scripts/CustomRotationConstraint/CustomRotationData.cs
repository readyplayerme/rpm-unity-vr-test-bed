using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Unity.Template.VR
{
    [Serializable]
    public struct CustomRotationData  : IAnimationJobData
    {
        public Transform constrainedObj;
        [SyncSceneToStream] public Transform sourceObj;

        public bool IsValid()
        {
            return !(constrainedObj == null || sourceObj == null);
        }

        public void SetDefaultValues()
        {
            constrainedObj = null;
            sourceObj = null;
        }
    }
}
