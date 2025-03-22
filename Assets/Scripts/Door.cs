using System.Collections.Generic;
using Inventory;
using Managers;
using Port;
using UnityEngine;

public class Door : MonoBehaviour, Interactable {
    bool activated = false;
    [SerializeField] private List<UsableItem> usableItems = new List<UsableItem>();

    public void Interact() {
        var index = 0;
        while (activated == false) {
            activated = UseItem(usableItems[index]);
            if (activated) Debug.Log("Door is activated");
            else Debug.Log("Door is de-activated");
            
            index++;
        }
    }

    private bool UseItem(UsableItem item) {
        List<UsableItem> keys = GameManagers.Inventory.GetAllOfType(item.type);
        if (keys.Count > 0) {
            GameManagers.Inventory.Use(keys[0]);

            return true;
        }
        Debug.Log("No usable items found");
        return false;
    }

    private void Update() {
        if (activated) {
            transform.gameObject.SetActive(false);
            Debug.DrawCircle(transform.parent.position, .5f, 1000, Color.green);
        }
    }
}