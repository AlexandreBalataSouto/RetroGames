using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidMove_Script : MonoBehaviour
{
    public float speed = 15;
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2((x * speed), 0);
    }
}
