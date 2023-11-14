using ObjectDetector.Pattern;
using UnityEngine;

namespace ObjectDetector.Test
{
    public class DetectablePoolableObjectPool : PoolableObjectPool
    {
        [SerializeField] private Vector3 objectPositionConstant;

        protected override void AddNewObject()
        {
            GameObject newObject = Instantiate(poolableObject.gameObject, parentObject);
            newObject.name = $"{poolableObject.name}-{_objects.Count}";
            newObject.SetActive(isAllObjectActive);
            PoolableObject newPoolableObject = newObject.GetComponent<PoolableObject>();
            newObject.transform.position =
                transform.position + new Vector3(_objects.Count * objectPositionConstant.x,
                    _objects.Count * objectPositionConstant.y, _objects.Count * objectPositionConstant.z);
            _pooledObjects.Add(newPoolableObject);
            _objects.Add(newObject);
        }
    }
}