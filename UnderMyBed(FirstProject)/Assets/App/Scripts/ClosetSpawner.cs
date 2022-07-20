using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject closet;
    [SerializeField] private Vector2 min;
    [SerializeField] private Vector2 max;
    private Vector2 rand;
    void Start()
    {
        float x = Random.Range(min.x, max.x), y = Random.Range(min.x,max.x);
        rand = new Vector2(x,y);
        Instantiate(closet,rand,Quaternion.identity);
    }

}
