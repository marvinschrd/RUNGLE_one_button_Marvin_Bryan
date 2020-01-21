using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    [SerializeField] GameObject prefabArrow;
    [SerializeField] Transform arrowSpawnPoint;
    //[SerializeField] AudioSource arrowSound;
    [SerializeField] float arrowSpeed = 10;
    [SerializeField] float shootTimer = 0f;
    [SerializeField] float warningTimer = 0f;
    [SerializeField] SpriteRenderer warning;
    bool canShoot = false;
    enum State
    {
        IDLE,
        WARNING,
        SHOOT,
    }
    State state = State.IDLE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.IDLE:
                break;
            case State.WARNING:
                shootTimer -= Time.deltaTime;
                if (shootTimer <= 0)
                {
                    warning.enabled = true;
                    warningTimer -= Time.deltaTime;
                    if (warningTimer <= 0)
                    {
                        warning.enabled = false;
                        state = State.SHOOT;
                        canShoot = true;
                    }
                }
                break;
            case State.SHOOT:
                if (canShoot)
                {
                        GameObject arrow = Instantiate(prefabArrow, arrowSpawnPoint);
                        arrow.GetComponent<Rigidbody2D>().velocity = Vector2.left * arrowSpeed;
                        canShoot = false;
                }
                break;
        }
    }
    //void shoot()
    //{
    //    if (canShoot)
    //    {
    //        shootTimer -= Time.deltaTime;
    //        if (shootTimer <= 0)
    //        { 
    //            GameObject arrow = Instantiate(prefabArrow, arrowSpawnPoint);
    //            arrow.GetComponent<Rigidbody2D>().velocity = Vector2.left * arrowSpeed;
    //            canShoot = false;
    //        }
    //    }
    //}
    private void OnBecameVisible()
    {
        state = State.WARNING;
    }
}
