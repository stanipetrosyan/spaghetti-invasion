using System.Collections.Generic;
using Dialogues;
using Inventory;
using Managers;
using Port;
using UnityEngine;

[RequireComponent(typeof(DialogueTrigger))]
public class ObjectWithItem : MonoBehaviour, Interactable{
    private DialogueTrigger dialogueTrigger;
    [SerializeField] private List<UsableItem> items = new();
    private bool interacted = false;

    private void Start() {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public void Interact() {
        if (interacted) return;
        
        GameManagers.Inventory.Add(items);

        if (dialogueTrigger) {
            dialogueTrigger.StartDialogue();
            interacted = true;
        }
    }
}