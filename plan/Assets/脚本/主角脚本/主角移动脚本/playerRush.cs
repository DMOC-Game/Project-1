using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRush : MonoBehaviour
{
    private Rigidbody2D rb;
    private float rushSpeed=5f;
    private int sum;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Rush") && sum>=30)
        {
            sum = 0;
            rb.velocity *= 5;
        }

    }
    private void FixedUpdate()
    {
        sum=Mathf.Clamp(++sum,0,30);
        
    }
}
