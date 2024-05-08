using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigid;
    PlayerMovement player;
    float xSpeed;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * 10;  
    }

    void Update()
    {
        rigid.velocity = new Vector2(xSpeed,0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }


    void OnCollisionEnter2D(Collision2D col){
        Destroy(gameObject);
    }
}
