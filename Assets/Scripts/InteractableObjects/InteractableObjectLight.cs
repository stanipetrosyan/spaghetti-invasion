using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractableObjectLight : MonoBehaviour {
    [Header("Impostazioni Colore")] public float frequenza = 5f;
    public Color darkerColor = Color.gray; 
    public Color lighterColor = Color.white; 

    private SpriteRenderer spriteRenderer;
    private bool active = true;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (active) {
            float oscillation = Mathf.Sin(Time.time * frequenza);
            float t = (oscillation + 1f) * 0.5f;
            spriteRenderer.color = Color.Lerp(darkerColor, lighterColor, t);
        }
        else {
            spriteRenderer.color = lighterColor;
        }
    }

    public void DeActivate() {
        active = false;
    }
}