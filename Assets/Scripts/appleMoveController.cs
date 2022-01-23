using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleMoveController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speedModificator = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(rb.position.x >= 5)
            rb.AddForce(new Vector2(speedModificator*-1, 0));
        if (rb.position.x <= -5)
            rb.AddForce(new Vector2(speedModificator, 0));
    }
}
