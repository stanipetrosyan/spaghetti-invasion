using UnityEngine;

public class Settings: MonoBehaviour {

    private void Start() {
        Hide();
    }

    public void Show() {
        this.transform.gameObject.SetActive(true);
    }

    public void Hide() {
        this.transform.gameObject.SetActive(false);
    }
}