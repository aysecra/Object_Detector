using ObjectDetector.Interfaces;
using ObjectDetector.Structs;
using UnityEngine;

namespace ObjectDetector.Test
{
    public class DetectedObject : IDetectable
    {
        private readonly DetectableObjectData _currDetectableObjectData;

        public DetectedObject(DetectableObjectData objectData)
        {
            _currDetectableObjectData = objectData;
        }

        public void OnDetected()
        {
            Debug.Log(_currDetectableObjectData.DetectableTransform.name + " is detected");
        }

        public void OnDestroyed()
        {
            
        }
    }
}