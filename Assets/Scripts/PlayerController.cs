using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    [SerializeField]Animator anim;
    int jumps = 2;
    bool isJumping = false;
    bool isGrounded = false;
    [SerializeField]float speed;
    [SerializeField]float jumpHeight;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        body.velocity = direction;
    }
    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(speed, body.velocity.y);
        if (body.velocity.y < -0.1f&&!isGrounded)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("midAir", true);
            direction = new Vector2(body.velocity.x, body.velocity.y * 1.1f);
        }
        if (isGrounded)
        {
            anim.SetBool("midAir", false);
        }
        JumpCheck();
    }
    void JumpCheck()
    {
        if(Input.GetKeyDown("space")&& jumps >0)
        {
            direction = new Vector2(body.velocity.x, jumpHeight);
            jumps -= 1;
            isJumping = true;
            anim.SetBool("isJumping", true);
           
        }
        if (Input.GetKeyUp("space"))
        {
            isJumping = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            jumps = 2;
            isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
