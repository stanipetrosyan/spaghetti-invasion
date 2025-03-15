using UnityEngine;

namespace DefaultNamespace.Inventory{
    
    [CreateAssetMenu(fileName = "UsableItem", menuName = "ScriptableObjects/UsableItem")]
    public class UsableItem: ScriptableObject{
        public int uses = 1;
        public string displayName;
        public string type = "Chiave generica";
        
        public void Use() {
            uses--;
        }

        public bool IsBroken() {
            return uses == 0;
        }
    }
}