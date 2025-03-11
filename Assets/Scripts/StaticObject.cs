using Port;
using UnityEngine;

namespace DefaultNamespace
{
    public class StaticObject : MonoBehaviour, Interactable
    {
        public void Interact()
        {
            Debug.Log("Oggetto interagibile");
        }
    }
}