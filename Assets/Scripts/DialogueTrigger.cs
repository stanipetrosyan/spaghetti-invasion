using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueCharacter{
    public string name;
    public Sprite icon;
}


[Serializable]
public class DialogueLine{
    public DialogueCharacter character;
    [TextArea(3, 10)] public string line;
}

[Serializable]
public class Dialogue{
    public List<DialogueLine> lines = new();
}

public class DialogueTrigger: MonoBehaviour{
    public Dialogue dialogue;

    private void TriggerDialogue() {
        Managers.GameManagers.Dialogue.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            TriggerDialogue();
        }
    }
}