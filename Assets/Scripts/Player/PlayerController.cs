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
    bool gameStarted = false;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpHeight;
    [SerializeField] GameObject deadMenu;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject StartingPanel;
    [SerializeField] AudioSource coin;
    [SerializeField] AudioSource jump;
    void Start()
    {
        Time.timeScale = 0f;
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        isDead = false;
    }
    void FixedUpdate()
    {
       body.velocity = direction;
    }
    void Update()
    {
        direction = new Vector2(speed, body.velocity.y);
        jumpAnim();
        JumpCheck();
        if (isDead)
        {
            loadDeathPanel();
        }
        if(!gameStarted)
        {
            UnloadStartingPanel();
        }
    }
    void JumpCheck()
    {
            Debug.Log(jumps);
        if (Input.GetKeyDown("space") && jumps > 0 && !isDead && gameStarted)
        {
            direction = new Vector2(body.velocity.x, jumpHeight);
            jumps -= 1;
            Debug.Log(jumps);
            anim.SetBool("isJumping", true);
            jump.Play();
        }
    }
    void jumpAnim()
    {
        if (body.velocity.y < -0.5f)
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
        if (collision.gameObject.tag == "coin")
        {
            coin.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            isGrounded = false;
        }
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
    void UnloadStartingPanel()
    {
        if (Input.GetKeyDown("space"))
        {
            StartingPanel.SetActive(false);
            Time.timeScale = 1f;
            gameStarted = true;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        deadMenu.SetActive(false);
        WinPanel.SetActive(false);
        StartingPanel.SetActive(true);
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
                Application.Quit();
            }
        }
    }
}