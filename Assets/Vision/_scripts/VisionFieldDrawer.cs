using System;
using System.Collections;
using UnityEngine;

namespace Assets.Vision
{
    [RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
    public class VisionFieldDrawer : MonoBehaviour
    {
        public static readonly float AngleShiftWhenZAxisIsDrawingBase = Quaternion.FromToRotation(Vector3.right, Vector3.forward).eulerAngles.y;

        public Vision VisionField { get; private set; }
        private int Rays { get; set; }
        private Mesh VisionMesh { get; set; }
        private Vector3[] Vertices => VisionMesh.vertices;
        private int[] Triangles => VisionMesh.triangles;
        private Coroutine DrawingCoroutine { get; set; }

        private void Awake()
        {
            VisionMesh = new Mesh();
            GetComponent<MeshFilter>().mesh = VisionMesh;
        }

        public void Begin(Vision visionField)
        {
            if(visionField == null) { throw new ArgumentNullException(nameof(visionField)); }

            AssignVisionField(visionField);
            DrawingCoroutine = StartCoroutine(RenderFieldOfView());
        }

        public void Stop()
        {
            StopCoroutine(DrawingCoroutine);
        }

        private void AssignVisionField(Vision visionField)
        {
            if (VisionField != visionField)
            {
                VisionField = visionField;
                Rays = Mathf.Max(Mathf.CeilToInt(VisionField.HorizontalViewAngle), 2);
                int verticesCount = Rays + 1;
                VisionMesh.vertices = new Vector3[verticesCount];
                VisionMesh.uv = new Vector2[verticesCount];
                VisionMesh.normals = new Vector3[verticesCount];
                VisionMesh.triangles = new int[(Rays - 1) * 3];
                for (int i = 0; i < VisionMesh.normals.Length; i++)
                {
                    VisionMesh.normals[i] = Vector3.up;
                }
                VisionMesh.vertices[0] = Vector3.zero;
            }
        }

        private IEnumerator RenderFieldOfView()
        {
            while (true)
            {
                float drawingAngle = CalculateDrawingAngle(VisionField);
                float deltaAngle = VisionField.HorizontalViewAngle / (Rays - 1);

                for (int i = 1, j = 0; i <= Rays; i++)
                {
                    Vertices[i] = CalculateVertex(VisionField, transform, drawingAngle);
                    AssignVerticesToTriangle(i, ref j);

                    drawingAngle -= deltaAngle;
                }

                yield return new WaitForSecondsRealtime(0.1f);
            }
        }
        private Vector3 CalculateVertex(Vision visionField, Transform origin, float angle)
        {
            Vector3 direction = GetTranslationDirection(angle);
            Ray ray = new Ray(origin.position, origin.TransformDirection(direction));
            if (Physics.Raycast(ray, out var hit, visionField.Radius, visionField.VisionObstacles, QueryTriggerInteraction.Ignore))
            {
                return origin.InverseTransformPoint(hit.point);
            }
            else
            {
                return direction * visionField.Radius;
            }
        }

        private Vector3 GetTranslationDirection(float angle)
        {
            float radians = Mathf.Deg2Rad * angle;
            return new Vector3(Mathf.Cos(radians), 0.0f, Mathf.Sin(radians));
        }

        private float CalculateDrawingAngle(Vision visionField)
        {
            float angle = AngleShiftWhenZAxisIsDrawingBase + visionField.FocusVectorRotation.eulerAngles.y + visionField.LeftVisionBorder;
            return angle;
        }

        public void AssignVerticesToTriangle(int vertexIndex, ref int triangleIndex)
        {
            if (vertexIndex > 1)
            {
                Triangles[triangleIndex] = 0;
                Triangles[triangleIndex + 1] = vertexIndex - 1;
                Triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
        }
    }
}


