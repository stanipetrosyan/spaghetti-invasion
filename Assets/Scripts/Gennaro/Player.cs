using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform movePoint;
    [SerializeField] private float radius;


    private Vector2 facingDirection;


    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (!(Vector3.Distance(transform.position, movePoint.position) < moveSpeed/20)) return;

        if (Mathf.Approximately(Mathf.Abs(Input.GetAxisRaw("Horizontal")), 1f))
        {
            Debug.Log("Player is moving horizontally");
            facingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        }

        if (Mathf.Approximately(Mathf.Abs(Input.GetAxisRaw("Vertical")), 1f))
        {
            Debug.Log("Player is moving vertically");
            facingDirection = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        }
    }
}