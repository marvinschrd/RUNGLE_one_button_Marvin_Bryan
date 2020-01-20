using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    [SerializeField] GameObject prefabArrow;
    [SerializeField] Transform arrowSpawnPoint;
    //[SerializeField] AudioSource arrowSound;
    [SerializeField] float arrowSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameVisible()
    {
        GameObject arrow = Instantiate(prefabArrow, arrowSpawnPoint);
        arrow.GetComponent<Rigidbody2D>().velocity = Vector2.left * arrowSpeed;
    }
}
