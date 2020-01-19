using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    int jumps = 2;
    bool isJumping = false;
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
        JumpCheck();
        if (body.velocity.y < -0.1f&&!isJumping)
        {
            direction = new Vector2(body.velocity.x, body.velocity.y * 1.1f);
        }
    }
    void JumpCheck()
    {
        if(Input.GetKeyDown("space")&& jumps >0)
        {
            direction = new Vector2(body.velocity.x, jumpHeight);
            jumps -= 1;
            isJumping = true;
        }
        if (Input.GetKeyUp("space"))
        {
            isJumping = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            jumps = 2;
        }
    }
}
