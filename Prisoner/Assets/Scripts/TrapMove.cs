using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rigid;
    BoxCollider2D boxcol;
    public float startTime;
    


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.velocity = new Vector2(0f,moveSpeed);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        moveSpeed = -moveSpeed;
    }


    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-Mathf.Sign(rigid.velocity.y),1f);
    }
}
