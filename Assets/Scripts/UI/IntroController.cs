using System.Collections;
using System.Collections.Generic;
using Dialogues;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {
    private DialogueSequence sequence;

    void Start() {
        sequence = GetComponent<DialogueSequence>();
    }
    
    void Update()
    {
        if (sequence.IsFinished() && !CutsceneManagers.Dialogue.IsActiveDialogue()) {
            SceneManager.LoadScene("Game");
        }
    }
}
