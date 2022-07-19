using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator model;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 moveVector;

    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        //actual movement
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveVector.x * speed, moveVector.y * speed);
        //animation
        model.SetFloat("Horizontal", moveVector.x);
        model.SetFloat("Vertical", moveVector.y);
    }
}
