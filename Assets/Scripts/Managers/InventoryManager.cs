using System.Collections.Generic;
using DefaultNamespace.Inventory;
using Port;
using UnityEngine;

namespace Managers
{
    public class InventoryManager : MonoBehaviour, IManager
    {
        private List<Item> inventory = new();
        
        public ManagerStatus Status { get; set; }
        public void Startup()
        {
            Status = ManagerStatus.Started;
        }


        public void Add(Item item)
        {
            inventory.Add(item);
        }

        public void Remove(Item item)
        {
            inventory.Remove(item);
        }
    }
}