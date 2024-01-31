using UnityEngine;

namespace ReadyPlayerMe.VR
{
    public class DebugForward : MonoBehaviour
    {
        [SerializeField] public Transform head;
        [SerializeField] public Transform leftHand;
        [SerializeField] public Transform rightHand;


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            var headLeftHandVector = leftHand.position - head.position;
            var headRightHandVector = rightHand.position - head.position;

            var normal = Vector3.Cross(headLeftHandVector, headRightHandVector);
            var normalOnPlane = Vector3.ProjectOnPlane(normal, Vector3.up);

            var centroid = (leftHand.position + rightHand.position) / 2f;


            Gizmos.DrawWireSphere(centroid, 0.05f);
            Gizmos.DrawRay(centroid, normalOnPlane);
        }
    }
}
