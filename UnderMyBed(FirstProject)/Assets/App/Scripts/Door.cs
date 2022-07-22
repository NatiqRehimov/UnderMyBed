using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject loading;
    [SerializeField] private Animator loadinganim;
    [SerializeField] private Sprite lastSpriteOfAnim;
    [SerializeField] private AudioSource winSound;
    [SerializeField]private GameObject winPoster;
    [SerializeField] private GameObject tryAgainText;
    private bool nearDoor;
    public int countOfActive = 0;
    private void Start()
    {
        tryAgainText.SetActive(false); 
        countOfActive = 0;
        winPoster.SetActive(false);
        nearDoor = false;
        button.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            nearDoor = true;
            button.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        nearDoor = false;
        button.SetActive(false);
    }
    private void Update()
    {
        InteractionButton();
        TryAgain();
    }

    private void TryAgain()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Main");
        }
    }

    private void InteractionButton()
    {
        if (Input.GetKeyDown(KeyCode.E) && nearDoor && countOfActive == 5)
        {
            loadinganim.SetBool("ButtonPressed", true);
            InTheEnd();
        }
        else if (Input.GetKeyUp(KeyCode.E) && nearDoor && countOfActive == 5)
        {
            loadinganim.SetBool("ButtonPressed", false);
            InTheEnd();
        }
    }
    private void InTheEnd()
    {
        if (loading.GetComponent<SpriteRenderer>().sprite == lastSpriteOfAnim)
        {
            winSound.Play();
            winPoster.SetActive(true);
            tryAgainText.SetActive(true);
        }
    }

}
