using Domain;
using Managers;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class AnxietyCounter : MonoBehaviour {
    public float anxiety;
    public bool hasAnxiety;
    public float smoothTime = 1.0f;
    private float time = 0f;
    public float heartBeat = 0f;

    [SerializeField] private Camera gameCamera;
    [SerializeField] private Player player;
    [SerializeField] private Image redScreen;
    private float minimum;
    private float maximum;


    private void Start() {
        Setup();
    }

    private void FixedUpdate() {
        if (anxiety <= 1) {
            GameManagers.Audio.StopHeartBeat();
            Setup();
            return;
        }

        GameManagers.Audio.PlayHeartBeat();
        HeartBeat();
        RedScreen();
    }

    private void Setup() {
        maximum = gameCamera.orthographicSize;
        minimum = 28;
        
        redScreen.color = new Color(0, 0, 0, 0);
    }
    

    private void RedScreen() {
        var alpha = (anxiety * 10) / 255;
        var red = (anxiety * 10) / 255;

        redScreen.color = new Color(red, 0, 0, alpha); 
    }

    private void HeartBeat() {
        gameCamera.orthographicSize = Mathf.Lerp(minimum, maximum, time);

        if (Mathf.Approximately(maximum, 30)) {
            time += heartBeat * 0.016f;// * Time.deltaTime;
        }
        else {
            time += (heartBeat * 3) * 0.016f;// * 3 * Time.deltaTime;
        }


        if (time > smoothTime) {
            if (hasAnxiety) {
                if (maximum > minimum) {
                    minimum -= 0.2f;
                }
                else {
                    maximum -= 0.2f;
                }

            }
            else {
                if (maximum > minimum) {
                    minimum += 0.6f;
                }
                else {
                    maximum += 0.6f;
                }
            }
            
            (maximum, minimum) = (minimum, maximum);
            time = 0.0f;
        }
    }

    public void IncreaseAnxiety(float amount) {
        if (anxiety >= 25) {
            player.GameOver(Reason.Light);
            return;
        }

        hasAnxiety = true;
        anxiety += amount * Time.deltaTime;
    }

    public void SetAnxiety(float amount) {
        anxiety = amount;
        
        hasAnxiety = true;
    }


    public void DecreaseAnxiety(float amount) {
        if (anxiety <= 0) return;

        hasAnxiety = false;
        anxiety -= amount * Time.deltaTime;
    }
}