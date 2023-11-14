using ObjectDetector.Interfaces;
using UnityEngine;

namespace ObjectDetector.Structs
{
    public struct DetectableObjectData
    {
        public Mesh Mesh;
        public Transform DetectableTransform;
        public IDetectable DetectableScript;
    }
}