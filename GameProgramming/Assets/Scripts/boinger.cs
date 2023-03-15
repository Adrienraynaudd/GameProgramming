using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boinger : MonoBehaviour
{
    public float bounceForce = 21f;
    public float bounceTime = 0.05f;
    public string orientation = "up";
    private bool OnBoinger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            OnBoinger = true;
            switch (orientation)
        {

            case "up":
                BounceUp(collision.gameObject);
                break;
            // case "down":
            //     BounceDown();
            //     break;
            // case "left":
            //     BounceLeft();
            //     break;
            case "right":
                BounceRight(collision.gameObject);
                break;
        }
            
        }
    }
    void Update()
    {
        
    }

    public void BounceUp(GameObject player)
    {
        if (OnBoinger == true)
        {   
            if (bounceTime > 0)
            {
                bounceTime -= Time.deltaTime;
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            }
            else
            {
                bounceTime = 0.5f;
                OnBoinger = false;
            }

        }
    }

    public void BounceRight(GameObject player)
    {
        if (OnBoinger == true)
        {
            if (bounceTime > 0)
            {
                bounceTime -= Time.deltaTime;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(27f , 0.1f) * bounceForce;
            }
            else
            {
                bounceTime = 0.5f;
                OnBoinger = false;
            }

        }
    }
}
