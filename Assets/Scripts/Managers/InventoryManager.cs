using System.Collections.Generic;
using System.Linq;
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
        
        public void Add(List<Item> item)
        {
            inventory.AddRange(item);
        }

        public List<T> GetAllOfType<T>() where T : Item
        {
            return inventory.OfType<T>().ToList();
        }

        public void Remove(Item item)
        {
            inventory.Remove(item);
        }
    }
}

