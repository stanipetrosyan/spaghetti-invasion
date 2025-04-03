using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace{
    public class GameOverPopup: MonoBehaviour{
        private TextMeshProUGUI text;

        private void Start() {
            text = GetComponent<TextMeshProUGUI>();
            if (text) {
                text.text = PlayerPrefs.GetString("GameOverReason");
            }
        }
    }
}