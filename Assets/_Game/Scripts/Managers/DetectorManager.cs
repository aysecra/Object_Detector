using System.Collections.Generic;
using ObjectDetector.Component;
using ObjectDetector.Interfaces;
using ObjectDetector.Structs;
using UnityEngine;

namespace ObjectDetector.Manager
{
    public class DetectorManager : Singleton<DetectorManager>
        , IUpdateListener
    {
        private List<DetectableObjectData> _detectableObjects = new List<DetectableObjectData>();

        private void Start()
        {
            UpdateManager.Instance.AddListener(this);
        }

        void IUpdateListener.ManagedUpdate()
        {
            if (_detectableObjects.Count > 0)
            {
                foreach (var detectableObject in _detectableObjects)
                {
                    ScreenToWorldPointData screenToWorldPointData =
                        CameraController.Instance.ScreenToWorldPoint(Input.mousePosition);

                    if (Logic.ObjectDetector.CalculateIsHitToObject(detectableObject, screenToWorldPointData))
                        detectableObject.DetectableScript.OnDetected();
                }
            }
        }

        public void AddDetectableObject(DetectableObjectData detectableObject)
        {
            if (!_detectableObjects.Contains(detectableObject))
            {
                _detectableObjects.Add(detectableObject);
            }
        }

        public void RemoveDetectableObject(DetectableObjectData detectableObject)
        {
            if (_detectableObjects.Contains(detectableObject))
            {
                _detectableObjects.Remove(detectableObject);
            }
        }

        private void OnDisable()
        {
            if(!gameObject.scene.isLoaded) return;

            UpdateManager.Instance.RemoveListener(this);
        }
    }
}