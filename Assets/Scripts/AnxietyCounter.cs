using Managers;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnxietyCounter : MonoBehaviour {
    public float anxiety;
    public float smoothTime = 1.0f;
    private float time = 0f;
    public float test = 0f;

    [SerializeField] private Light2D light2D;
    [SerializeField] private Camera gameCamera;
    [SerializeField] private Player player;
    private float minimum = 26f;
    private float maximum;


    private void Start() {
        maximum = gameCamera.orthographicSize;
    }

    private void Update() {
        if (anxiety <= 1) {
            GameManagers.Audio.StopHeartBeat();
            return;
        }

        GameManagers.Audio.PlayHeartBeat();
        HeartBeat();
        RedScreen();
    }

    private void RedScreen() {
        var green = (255 - anxiety * 10) / 255;
        var blue = (255 - anxiety * 10) / 255;

        light2D.color = new Color(1, green, blue, 1);
    }

    private void HeartBeat() {
        gameCamera.orthographicSize = Mathf.Lerp(minimum, maximum, time);

        if (Mathf.Approximately(maximum, 30)) {
            time += test * Time.deltaTime;
        }
        else {
            time += test * 3 * Time.deltaTime;
        }


        if (time > smoothTime) {
            if (maximum > minimum) {
                minimum -= 0.2f;
            }
            else {
                maximum -= 0.2f;
            }

            (maximum, minimum) = (minimum, maximum);
            time = 0.0f;
        }
    }

    public void IncreaseAnxiety(float amount) {
        if (anxiety >= 25) {
            player.GameOver("Sei diventato uno di loro");
            return;
        }

        anxiety += amount * Time.deltaTime;
    }


    public void DecreaseAnxiety(float amount) {
        if (anxiety <= 0) return;

        anxiety -= amount * Time.deltaTime;
    }
}