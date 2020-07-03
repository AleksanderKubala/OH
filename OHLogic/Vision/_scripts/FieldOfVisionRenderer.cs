using System.Collections;
using OHLogic.Body;
using UnityEngine;

namespace OHLogic.Vision
{
    [RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
    public class FieldOfVisionRenderer : MonoBehaviour
    {
        #pragma warning disable 649

        [SerializeField]
        private LayerMask VisionMasks;

        #pragma warning restore 649

        public Eye eye;
        public int Rays = 2;
        private Mesh mesh;
        private Vector3[] vertices;
        private Vector2[] uv;
        private Vector3[] normals;
        private int[] triangles;
        private float initialYAngleShift;

        private float DeltaAngle => eye.HorizontalViewAngle / (Rays - 1);

        private void Start()
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            vertices = new Vector3[Rays + 1];
            uv = new Vector2[vertices.Length];
            normals = new Vector3[vertices.Length];
            triangles = new int[(Rays - 1) * 3];
            vertices[0] = Vector3.zero;
            normals[0] = Vector3.up;

            for (int i = 1; i <= Rays; i++)
            {
                normals[i] = Vector3.up;
            }
            if (gameObject.transform.root.name == "Ragdoll")
            {
                Debug.Log("Check");
            }
            initialYAngleShift = Quaternion.FromToRotation(eye.transform.forward, Vector3.forward).eulerAngles.y;

            StartCoroutine(RenderFieldOfView());
        }

        private IEnumerator RenderFieldOfView()
        {
            while (true)
            {
                float drawingAngle = CalculateDrawingAngle();
                for (int i = 1, j = 0; i <= Rays; i++)
                {
                    vertices[i] = CalculateVertex(drawingAngle);
                    AssignVerticesToTriangle(i, ref j);

                    drawingAngle -= DeltaAngle;
                }

                UpdateMesh();

                yield return new WaitForSecondsRealtime(0.1f);
            }
        }

        private Vector3 CalculateVertex(float angle)
        {
            Vector3 direction = GetTranslationDirection(angle);
            Ray ray = new Ray(transform.position, transform.TransformDirection(direction));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, eye.Radius, VisionMasks, QueryTriggerInteraction.Ignore))
            {
                return transform.InverseTransformPoint(hit.point);
            }
            else
            {
                return direction * eye.Radius;
            }
        }

        private void AssignVerticesToTriangle(int vertexIndex, ref int triangleIndex)
        {
            if (vertexIndex > 1)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
        }

        private void UpdateMesh()
        {
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.normals = normals;
        }

        private Vector3 GetTranslationDirection(float angle)
        {
            float radians = Mathf.Deg2Rad * angle;
            return new Vector3(Mathf.Cos(radians), 0.0f, Mathf.Sin(radians));
        }

        private float CalculateDrawingAngle()
        {

            float angle = (90.0f + initialYAngleShift) + eye.LeftVisionBorder;
            return angle;
        }
    }
}


