using UnityEngine;

public class Popup: MonoBehaviour {

    private void Start() {
        Hide();
    }

    public void Show() {
        transform.gameObject.SetActive(true);
    }

    public void Hide() {
        transform.gameObject.SetActive(false);
    }
}