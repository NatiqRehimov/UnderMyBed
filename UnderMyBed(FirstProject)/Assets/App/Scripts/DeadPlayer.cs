using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class DeadPlayer : MonoBehaviour
{
    [SerializeField] private Animator model;
    [SerializeField] private GameObject monster;
    [SerializeField] private Sprite lastSpriteOfAnim;
    private GameObject screamer;
    [SerializeField]private AudioSource bigChomp;

    private void Awake()
    {
        screamer = GameObject.Find("Screamer");
    }
    private void Start()
    {
        screamer.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Monster")
        {
            model.SetBool("Attack",true);
            bigChomp.Play();
            if (model.GetComponent<SpriteRenderer>().sprite == lastSpriteOfAnim)
            {
                Debug.Log("FUCK");
                model.SetBool("Attack",false);
                screamer.SetActive(true);
                SceneManager.LoadScene("Main");
            }
        }
    }
}
