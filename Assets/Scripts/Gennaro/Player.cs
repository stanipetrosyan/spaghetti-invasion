using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float radius = 0.5f;
    private Vector2 direction = Vector2.zero;
    
    [SerializeField] private LayerMask interactableLayer;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        if (moveHorizontal != 0)
        {
            direction = new Vector2(moveHorizontal, 0);
        }
        else if (moveVertical != 0)
        {
            direction = new Vector2(0, moveVertical);
        }
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;
        
        rb.velocity = movement;
        if (Physics2D.OverlapCircle(rb.position + direction, radius, interactableLayer)) {
            Debug.Log("Interactable!");
        }
    }
}