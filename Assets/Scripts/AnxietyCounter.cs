using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class AnxietyCounter : MonoBehaviour {
    public float anxiety;
    public float smoothTime = 1.0f;
    private float time = 0f;

    [SerializeField] private Light2D light2D;
    [SerializeField] private Camera gameCamera;
    private float minimum = 26f;
    private float maximum;

    private void Start() {
        maximum = gameCamera.orthographicSize;
    }

    private void Update() {
        if (anxiety <= 1) return;
        
        HeartBeat();
        RedScreen();
    }

    private void RedScreen() {
        var green = (255 - anxiety*10) / 255;
        var blue = (255 - anxiety*10) / 255;
        
        light2D.color = new Color(1, green,  blue, 1);
    }

    private void HeartBeat() {
        gameCamera.orthographicSize = Mathf.Lerp(minimum, maximum, time);

        time += anxiety * Time.deltaTime;

        if (time > smoothTime) {
            (maximum, minimum) = (minimum, maximum);
            time = 0.0f;
        }
    }

    public void IncreaseAnxiety(float amount) {
        if (anxiety >= 25) return;
        
        anxiety += amount * Time.deltaTime;
    }
    

    public void DecreaseAnxiety(float amount) {
        if (anxiety <= 0) return;
        
        anxiety -= amount * Time.deltaTime;
    }
}