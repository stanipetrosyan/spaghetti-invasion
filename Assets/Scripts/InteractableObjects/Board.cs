using System.Collections;
using System.Collections.Generic;
using Managers;
using Port;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour, Interactable{
    
    [SerializeField] private Image board;
    [SerializeField] private TextMeshProUGUI closeText;

    public void Interact() {
        board.gameObject.SetActive(true);
        closeText.gameObject.SetActive(true);
        GameManagers.Input.SetCanMove(false);
        GameManagers.Interact.Deactivate();
    }
}
