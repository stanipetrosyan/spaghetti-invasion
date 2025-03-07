using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Lights {
    public class Intermittence: MonoBehaviour {
        private Light2D light2D;

        public float minimum = 0.0f;
        public float maximum =  1.0f;
        public float time;

        private void Start() {
            light2D = GetComponent<Light2D>();
        }

        private void Update() {
            light2D.intensity = Mathf.Lerp(minimum, maximum, time);

            time += 0.1f * Time.deltaTime;
            
            if (time > 1.0f) {
                (maximum, minimum) = (minimum, maximum);
                time = 0.0f;
            }
        }
        
    }
}