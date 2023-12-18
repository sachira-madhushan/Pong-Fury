using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rg;
    public Game gameScript;
    public Vector2 ballDefaultPosition;
    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        ballDefaultPosition = this.transform.position;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedExit")
        {
            this.transform.position = ballDefaultPosition;
            rg.velocity =new Vector2(0,0);
            gameScript.IncreaseGreenScore();
            gameScript.TimerStart();
        }
        else if (collision.gameObject.tag == "GreenExit")
        {
            this.transform.position = ballDefaultPosition;
            rg.velocity = new Vector2(0, 0);
            gameScript.IncreaseRedScore();
            gameScript.TimerStart();
        }
    }
    
    public void addForce()
    {
        int x = Random.Range(-300, 300);
        int y = Random.Range(-300, 300);
        rg.AddForce(new Vector2(x, y));
    }

    public void RefreshButton()
    {
        this.transform.position = ballDefaultPosition;
        rg.velocity = new Vector2(0, 0);
        gameScript.TimerStart();
    }
}
