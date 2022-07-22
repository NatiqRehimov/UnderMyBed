using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterRoom : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            wall.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            wall.SetActive(true);
        }
    }
}
