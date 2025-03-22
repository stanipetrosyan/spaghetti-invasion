using System.Collections.Generic;
using Dialogues;
using Managers;
using Port;
using UnityEngine;

[RequireComponent(typeof(DialogueTrigger))]
public class ObjectWithoutItem : MonoBehaviour, Interactable{
    private DialogueTrigger dialogueTrigger;

    private void Start() {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public void Interact() {
        if (dialogueTrigger) {
            dialogueTrigger.StartDialogue();
        }
    }
}