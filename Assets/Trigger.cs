using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject pPlayer;
    public GameObject CP1;

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           pPlayer.transform.position = CP1.transform.position;
        }
    }
}
