using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHiding : MonoBehaviour
{
    [SerializeField] private GameObject button;
    public bool canHide;
    public bool canShow;


    private void Start()
    {
        canShow = false;
        button.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canHide = true;
            button.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            button.SetActive(false);
            canHide = false;
            canShow = false;
        }
    }
   

}
