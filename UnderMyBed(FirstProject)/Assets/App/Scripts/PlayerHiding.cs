using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHiding : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject player;
    private bool canHide;


    private void Start()
    {
        button.SetActive(false);
    }
    private void Update()
    {
        GetInCloset(canHide);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canHide = true;
            button.SetActive(true);
            GetInCloset(canHide);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        button.SetActive(false);
    }
    private void GetInCloset(bool canI)
    {
        if (Input.GetKeyDown(KeyCode.E) && canHide)
        {
            player.SetActive(false);
        }
    }

}
