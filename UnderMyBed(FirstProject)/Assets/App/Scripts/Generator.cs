using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject gen;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject loading;
    [SerializeField] private Animator loadinganim;
    [SerializeField] private Sprite lastSpriteOfAnim;
    [SerializeField] private Door gens;
    private bool nearGen;
    private bool completeGen;
    private void Start()
    {
        nearGen = false;
        button.SetActive(false);
        completeGen = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !completeGen)
        {
            nearGen = true;
            button.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && !completeGen)
        {
            nearGen = false;
            button.SetActive(false);
        }
    }
    private void Update()
    {
        InteractionButton();
    }

    private void InteractionButton()
    {
        if (Input.GetKeyDown(KeyCode.E) && nearGen)
        {
            loadinganim.speed = 0.05f;
            loadinganim.SetBool("ButtonPressed", true);
            InTheEnd();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            loadinganim.SetBool("ButtonPressed", false);
            loadinganim.speed = 0.1f;
            InTheEnd();
        }
        else if (Input.GetKey(KeyCode.E) && !nearGen)
        {
            loadinganim.SetBool("ButtonPressed", false);
        }
    }
    private void InTheEnd()
    {
        if (loading.GetComponent<SpriteRenderer>().sprite == lastSpriteOfAnim)
        {
            completeGen = true;
            button.SetActive(false);
            gens.countOfActive++;
            gen.GetComponent<Generator>().enabled = false;
        }
    }
}
