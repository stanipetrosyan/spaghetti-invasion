using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Impostazioni Colore")]
    public float frequenza = 5f;
    public Color coloreMinimo = Color.gray; // Valore RGB minimo
    public Color coloreMassimo = Color.white; // Valore RGB massimo

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float oscillazione = Mathf.Sin(Time.time * frequenza);
        float t = (oscillazione + 1f) * 0.5f;
        spriteRenderer.color = Color.Lerp(coloreMinimo, coloreMassimo, t);
    }
}
