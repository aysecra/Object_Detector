using ObjectDetector.Interfaces;
using ObjectDetector.Pattern;

namespace ObjectDetector.Test
{
    public class DetectablePoolableObject : PoolableObject, IDetectable
    {
        public void OnDetected()
        {
            print(gameObject.name + " is detected (detectable poolable)");
        }
    }
}
