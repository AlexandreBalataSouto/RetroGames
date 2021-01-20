using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone_Script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball"){
            other.gameObject.GetComponent<ArkanoidBall_Script>().ResetBall();
            GetComponent<AudioSource>().Play();
        }
    }
}

