using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnxietyCounter : MonoBehaviour {
    public float anxiety;
    public float smoothTime = 1.0f;
    private float time = 0f;

    [SerializeField] private Light2D light;
    [SerializeField] private Camera camera;
    private float minimum = 24f;
    private float maximum;

    private void Start() {
        maximum = camera.orthographicSize;
    }

    private void Update() {
        HeartBeat();
        RedScreen();
    }

    private void RedScreen() {
        var green = (255 - anxiety*10) / 255;
        var blue = (255 - anxiety*10) / 255;
        
        light.color = new Color(1, green,  blue, 1);
    }

    private void HeartBeat() {
        camera.orthographicSize = Mathf.Lerp(minimum, maximum, time);

        time += anxiety * Time.deltaTime;

        if (time > smoothTime) {
            (maximum, minimum) = (minimum, maximum);
            time = 0.0f;
        }
    }
}