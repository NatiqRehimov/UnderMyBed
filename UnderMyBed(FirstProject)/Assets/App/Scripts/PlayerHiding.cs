using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHiding : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject loading;
    [SerializeField] private Animator loadinganim;
    [SerializeField] private GameObject player;
    [SerializeField] private Sprite lastSpriteOfAnim;
    [SerializeField] private float animCD;
    private bool canHide;


    private void Start()
    {
        button.SetActive(false);
    }
    private void Update()
    {
        GetInCloset();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canHide = true;
            button.SetActive(true);
            GetInCloset();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        button.SetActive(false);
    }
    private void GetInCloset()
    {
        if (Input.GetKey(KeyCode.E) && canHide)
        {
            loadinganim.SetBool("ButtonPressed", true);
            if (loading.GetComponent<SpriteRenderer>().sprite == lastSpriteOfAnim)
            {
                Debug.Log("NAKANECTO");
            }
        }
        else
        {   
            loadinganim.SetBool("ButtonPressed", false);
        }
    }

}
