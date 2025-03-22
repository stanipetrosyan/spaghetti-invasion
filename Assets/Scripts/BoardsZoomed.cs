using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class BoardsZoomed : MonoBehaviour{
    void Start() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(false);
            }
            GameManagers.Input.SetCanMove(true);
        }
    }
}