using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainMenuController : MonoBehaviour{

    [SerializeField] private Settings settings;

    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void OpenSettings() {
        settings.Show();
    }

    public void CloseSettings() {
        settings.Hide();
    }
    
}
