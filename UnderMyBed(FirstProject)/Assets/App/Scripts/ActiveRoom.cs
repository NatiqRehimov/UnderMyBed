using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ActiveRoom : MonoBehaviour
{
    [SerializeField] private TilemapRenderer room;
    [SerializeField] private GameObject objects;
    [SerializeField] private GameObject player;
    private void Start()
    {
        objects.SetActive(false);
        room.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            objects.SetActive(true);
            room.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            objects.SetActive(false);

            room.enabled = false;
        }
    }


}
