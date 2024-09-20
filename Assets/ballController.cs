using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public float ballSpeed = 10f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchBall()
    {
        float randomDireciton = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(randomDireciton, Random.Range(-1f, 1f)).normalized * ballSpeed;
    }

    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * ballSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
