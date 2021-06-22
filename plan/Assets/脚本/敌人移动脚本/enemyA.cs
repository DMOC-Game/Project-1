using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyA : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private Vector2 v;
    private Rigidbody2D rb;

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        v = (target.position-transform.position).normalized;
        //transform.up = v; //µÐÈËÐý×ª
        v = v * speed;
    }

    void FixedUpdate()
    {
        rb.velocity = v;
        
    }
}
