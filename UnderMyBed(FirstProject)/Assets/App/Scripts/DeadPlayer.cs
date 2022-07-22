using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlayer : MonoBehaviour
{
    [SerializeField] private Animator modelOfMonster;
    [SerializeField] private GameObject modelOfPlayer;
    [SerializeField] private Sprite lastSpriteOfChompAnim;
    [SerializeField]private AudioSource bigChomp;
    [SerializeField] private GameObject tryAgainText;
    private GameObject screamer;

    private void Awake()
    {
        screamer = GameObject.Find("Screamer");
    }
    private void Start()
    {
        tryAgainText.SetActive(false);
        screamer.SetActive(false);
    }
    private void Update()
    {
        TryAgain();
        WhosUnder();
    }
    private void WhosUnder()
    {
        if(modelOfPlayer.transform.position.y > modelOfMonster.transform.position.y)
        {
            modelOfPlayer.GetComponent<SpriteRenderer>().sortingOrder = 1;
            modelOfMonster.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else 
        {
            modelOfPlayer.GetComponent<SpriteRenderer>().sortingOrder = 2;
            modelOfMonster.GetComponent<SpriteRenderer>().sortingOrder = 1;

        }
    }
    private void TryAgain()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Main");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Monster" && modelOfPlayer.activeSelf)
        {
            modelOfMonster.SetBool("Attack",true);
            bigChomp.Play();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        LoadSceneAgain();
    }

    private void LoadSceneAgain()
    {
        if (modelOfMonster.GetComponent<SpriteRenderer>().sprite == lastSpriteOfChompAnim)
        {
            modelOfMonster.SetBool("Attack", false);
            screamer.SetActive(true);
            tryAgainText.SetActive(true);
        }
    }
}
