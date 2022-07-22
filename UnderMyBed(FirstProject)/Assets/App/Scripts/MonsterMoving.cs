using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MonsterMoving : MonoBehaviour
{
    [SerializeField] private AudioClip roar;
    [SerializeField] private AudioSource source;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D monsterRb;
    [SerializeField] private float moveSpeed;
    private bool faceLeft = true;
    private bool see = false;
    private bool isWall = false;
    private Vector2 moveVector;
    [SerializeField]private Vector2 max,min;

    void Update()
    {
        if (see && player.activeSelf) { Follow(); }
        else 
        {
            if (!isWall) { ChillyWalk(); }
            else { monsterRb.velocity = new Vector2(0f,0f); isWall = false; }
        }
    }

    private void Follow()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        moveVector = direction;
        monsterRb.MovePosition((Vector2)transform.position + (moveVector * moveSpeed*0.05f));

        if (moveVector.x > 0 && faceLeft) { Flip(); }
        else if (moveVector.x < 0 && !faceLeft) { Flip(); }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && player.activeSelf) { see = true; source.PlayOneShot(roar); }
        if (other.tag == "Wall") { isWall = true; }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") { see = false; source.Stop(); }
        if (other.tag == "Wall") { isWall = false; }
    }

    private void ChillyWalk()
    {
        RandomDestination();
        monsterRb.AddForce(moveVector*moveSpeed);
        if (moveVector.x > 0 && faceLeft) { Flip(); }
        else if (moveVector.x < 0 && !faceLeft) { Flip(); }
    }
    private void RandomDestination()
    {
        moveVector = new Vector2(UnityEngine.Random.Range(min.x,max.x),UnityEngine.Random.Range(min.y,max.y)).normalized;
    }
    private void Flip() 
    {
        faceLeft = !faceLeft;
        transform.localScale = new Vector3(-1,1,1);
    }
}
