using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibles : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score.score += 10;
        Destroy(gameObject);
    }
}
