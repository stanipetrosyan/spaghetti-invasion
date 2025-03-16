using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Screen;

namespace UI {
    public class DialoguePopup : MonoBehaviour {
        [SerializeField] private Image background;


        private void Start() {
            var backRect = background.GetComponent<RectTransform>();
            var rect = background.GetComponent<RectTransform>();
            Debug.Log(width);
            Debug.Log(height);
            rect.anchoredPosition = Vector2.down;
            backRect.sizeDelta = new Vector2(width, height / 4);
        }
    }
}