using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator model;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private bool shift = false;
    private bool faceRight = true;
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

        if (moveVector.x < 0 && faceRight) { Flip(); }
        else if (moveVector.x > 0 && !faceRight) { Flip(); }
        Run();
        //animation
        model.SetFloat("Horizontal", moveVector.x);
        model.SetFloat("Vertical", moveVector.y);
        model.SetBool("Shift", shift);
    }
    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shift = true;
            model.SetBool("Shift", shift);
            speed = 10f;
        }
        else
        {
            shift = false;
            model.SetBool("Shift", shift);
            speed = 5f;
        }
    }
    private void Flip()
    {
        faceRight = !faceRight;
        model.transform.Rotate(0f,180f,0f);
    }
}
