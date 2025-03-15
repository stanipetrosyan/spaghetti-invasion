using UnityEngine;

namespace DefaultNamespace.Inventory
{
    public class Key: MonoBehaviour, Item 
    {
        [SerializeField] private int uses { get; }
        [SerializeField] private string type { get; }
        
    }
}