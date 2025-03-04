using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Lights {
    public class Intermittence: MonoBehaviour {
        [SerializeField] private Light2D light;

        public float minimum = 0.0f;
        public float maximum =  1.0f;
        public float time;

        private void Update() {
            light.intensity = Mathf.Lerp(minimum, maximum, time);

            time += 0.1f * Time.deltaTime;
            
            if (time > 1.0f) {
                (maximum, minimum) = (minimum, maximum);
                time = 0.0f;
            }
        }
        
    }
}