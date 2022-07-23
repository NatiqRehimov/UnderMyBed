using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFrontOfPlayer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer objects;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject monster;
    private void Update()
    {
        PlayerInFront();
    }
    private void PlayerInFront()
    {
        if (objects.transform.position.y > player.transform.position.y || objects.transform.position.y > monster.transform.position.y)
        {
            objects.sortingOrder = 1;
        }
        else if (objects.transform.position.y < player.transform.position.y || objects.transform.position.y < monster.transform.position.y)
        {
            objects.sortingOrder = 3;
        }
    }
}
