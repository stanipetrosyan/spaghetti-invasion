using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace.Inventory
{
    [System.Serializable]
    public abstract class Item : MonoBehaviour{
        [SerializeField] private int uses = 1;
        [SerializeField] private string displayName;

        public void Use() {
            uses--;
        }

        public bool IsBroken() {
            return uses == 0;
        }
    }
}