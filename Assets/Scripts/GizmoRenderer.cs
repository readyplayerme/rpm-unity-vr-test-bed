using UnityEngine;

namespace ReadyPlayerMe.VR
{
    [ExecuteInEditMode]
    public class GizmoRenderer : MonoBehaviour
    {
        public enum GizmoType
        {
            Sphere,
            Cube
        }

        [SerializeField] private GizmoType gizmoType = GizmoType.Sphere;
        [SerializeField] private float gizmoSize = 0.1f;
        [SerializeField] private Color gizmoColor = Color.yellow;

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmoColor;

            switch (gizmoType)
            {
                case GizmoType.Sphere:
                    Gizmos.DrawWireSphere(transform.position, gizmoSize);
                    break;

                case GizmoType.Cube:
                    Matrix4x4 originalMatrix = Gizmos.matrix;

                    Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
                    Gizmos.DrawWireCube(Vector3.zero, Vector3.one * gizmoSize);

                    Gizmos.matrix = originalMatrix;
                    break;
            }
        }
    }
}