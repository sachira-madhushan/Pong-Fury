using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rg;
    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.AddForce(new Vector2(300,200));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*rg.velocity = new Vector2(-1.2f,-1.2f);*/
    }
    void Update()
    {
        
    }
}
