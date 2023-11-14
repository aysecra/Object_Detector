using ObjectDetector.Structs;
using UnityEngine;

namespace ObjectDetector.Logic
{
    public static class ObjectDetector
    {
        public static bool CalculateIsHitToObject(DetectableObjectData objectData,
            ScreenToWorldPointData screenToWorldPointData)
        {
            Vector3 position = objectData.DetectableTransform.position;
            Vector3 minBound = objectData.Mesh.bounds.min + position;
            Vector3 maxBound = objectData.Mesh.bounds.max + position;
            float dist = (position.z - screenToWorldPointData.Origin.z) / screenToWorldPointData.Direction.z;
            Vector3 hitPoint = screenToWorldPointData.Origin + screenToWorldPointData.Direction * dist;

            if (hitPoint.x > maxBound.x || hitPoint.x < minBound.x ||
                hitPoint.y > maxBound.y || hitPoint.y < minBound.y)
                return false;

            return IsHitMesh(objectData, screenToWorldPointData);
        }

        private static bool IsHitMesh(DetectableObjectData objectData, ScreenToWorldPointData screenToWorldPoint)
        {
            Vector3 position = objectData.DetectableTransform.position;
            var vertices = objectData.Mesh.vertices;
            var triangles = objectData.Mesh.triangles;

            int triangleCount = triangles.Length / 3;
            for (int i = 0; i < triangleCount; i++)
            {
                var p1 = vertices[triangles[i * 3]] + position;
                var p2 = vertices[triangles[i * 3 + 1]] + position;
                var p3 = vertices[triangles[i * 3 + 2]] + position;

                if (Calculator.TriangleIntersect(p1, p2, p3, screenToWorldPoint)) return true;
            }

            return false;
        }
    }
}