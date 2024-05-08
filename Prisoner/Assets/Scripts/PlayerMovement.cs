using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    
    public Vector2 moveInput;
    public Rigidbody2D rigid;
    Animator anim;
    CapsuleCollider2D capcol;
    public BoxCollider2D feetcol;
    SpriteRenderer render;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform Gun;

    [SerializeField] float speed = 4.0f;
    [SerializeField] float climbSpeed = 2.0f;
    [SerializeField]public float jumpSpeed = 8.0f;
    float startGravity;
    
    public bool playerVertical;
    public bool playerHorizontalSpeed;
    public bool isAlive;

    
    


    void Start()
    {
        
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        feetcol = GetComponent<BoxCollider2D>();
        render = GetComponent<SpriteRenderer>();
        isAlive = true;
        startGravity = rigid.gravityScale;
    }

 
    void Update()
    {
        if (!isAlive )
        {
            return;
        }

        Run();
        FlipSprite();
        ClimbLadder();
        Die();
        
    }

    
    
    
    void OnMove(InputValue value)
    {
        if (!isAlive )
        {
            return;
        }

        moveInput = value.Get<Vector2>();
        // Debug.Log(moveInput);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * speed, rigid.velocity.y);
        rigid.velocity = playerVelocity;

        if (playerHorizontalSpeed)
        {
            anim.SetBool("isRunning",true);
        }
        else
        {
            anim.SetBool("isRunning",false);
        }
    }

    void ClimbLadder()
    {
        if (!feetcol.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            rigid.gravityScale = startGravity;
            anim.SetBool("isClimbing",false);
            
            return;
        }
        
        Vector2 climbVelocity = new Vector2(rigid.velocity.x,moveInput.y * climbSpeed);
        rigid.velocity = climbVelocity;
        rigid.gravityScale = 0;
        
        playerVertical = Mathf.Abs(rigid.velocity.y) > Mathf.Epsilon;
        anim.SetBool("isClimbing",playerVertical);
        
    }

    public void OnJump(InputValue value)
    {
        if (!isAlive ) {return;}

        // if (!feetcol.IsTouchingLayers(LayerMask.GetMask("Ground")))
        // {
        //     return;
        // }

        if (value.isPressed && feetcol.IsTouchingLayers(LayerMask.GetMask("Ground","Climb")))
        {
            SoundMnager.instance.FxPlay(0);
            rigid.velocity += new Vector2(0f,jumpSpeed);
        }
    }

    void FlipSprite()
    {
        playerHorizontalSpeed = Mathf.Abs(rigid.velocity.x) > Mathf.Epsilon;
        
        if (playerHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigid.velocity.x),1f);
        }
    }

    void Die()
    {
        if (capcol.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazards")))
        {
            SoundMnager.instance.FxPlay(1);
            isAlive = false;
            anim.SetTrigger("Dying");
            rigid.velocity = new Vector2(0,8);
            FindObjectOfType<GameSession>().ProcessPlayerDeath(); 
    
        }
    }

    /*void OnFire(InputValue val)
    {
        if (!isAlive ) {return;}
        Vector3 fireDirection = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        Instantiate(Bullet,Gun.position, transform.rotation);
        
    }*/

   
}
