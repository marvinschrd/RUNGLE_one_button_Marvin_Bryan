using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    [SerializeField] Animator anim;
    SpriteRenderer sprite;
    int jumps = 2;
    bool isGrounded = false;
    bool isDead = false;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpHeight;
    [SerializeField] GameObject deadMenu;
    [SerializeField] GameObject WinPanel;

    void Start()
    {
        Time.timeScale = 1f;
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        isDead = false;
    }

    void FixedUpdate()
    {
        body.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(speed, body.velocity.y);
        jumpAnim();
        JumpCheck();
        if(isDead)
        {
            loadDeathPanel();
        }
    }

    void JumpCheck()
    {
        if (Input.GetKeyDown("space") && jumps > 0&& !isDead)
        {
            direction = new Vector2(body.velocity.x, jumpHeight);
            jumps -= 1;
            anim.SetBool("isJumping", true);
        }
    }

    void jumpAnim()
    {
        if (body.velocity.y < -0.1f)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("midAir", true);
            direction = new Vector2(body.velocity.x, body.velocity.y * 1.1f);
        }
        if (isGrounded)
        {
            anim.SetBool("midAir", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jumps = 2;
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

    public void killPlayer()
    {
        isDead = true;
    }

    void loadDeathPanel()
    {
        Time.timeScale = 0f;
        deadMenu.SetActive(true);
        if (Input.GetKeyDown("space"))
        {
            Restart();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        deadMenu.SetActive(false);
        WinPanel.SetActive(false);
        Score.score = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "win")
        {
            isDead = true;
            WinPanel.SetActive(true);
            if (Input.GetKeyDown("space"))
            {
                Restart();
            }
        }
    }
}