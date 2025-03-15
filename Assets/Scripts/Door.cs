using System;
using System.Collections.Generic;
using DefaultNamespace.Inventory;
using Managers;
using Port;
using UnityEngine;

namespace DefaultNamespace
{
    public class Door : MonoBehaviour, Interactable
    {
        bool activated = false;

        public void Interact()
        {
            InventoryManager inventoryManager = Managers.GameManagers.Inventory;
            if (!inventoryManager)
            {
                Debug.Log("No inventory manager");
            }
            List<UsableItem> keys = Managers.GameManagers.Inventory.GetAllOfType("Chiave");
            if (keys.Count > 0)
            {
                Managers.GameManagers.Inventory.Use(keys[0]);
                
                activated = !activated;
                if (activated) Debug.Log("Door is activated");
                else Debug.Log("Door is de-activated");
            }
            else
            {
                Debug.Log("No keys found");
            }
        }

        private void Update()
        {
            if (activated)
            {
                transform.gameObject.SetActive(false);
                Debug.DrawCircle(transform.parent.position, .5f, 1000, Color.green);
            }
        }
    }
}