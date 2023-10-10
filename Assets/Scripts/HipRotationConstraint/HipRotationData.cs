using System;
using System.Transactions;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Unity.Template.VR
{
    [Serializable]
    public struct HipRotationData  : IAnimationJobData
    {
        public Transform constrainedObject;
        [SyncSceneToStream] public Transform sourceObject;
        
        public bool IsValid()
        {
            return !(constrainedObject == null || sourceObject == null);
        }

        public void SetDefaultValues()
        {
            constrainedObject = null;
            sourceObject = null;
        }
    }
}
