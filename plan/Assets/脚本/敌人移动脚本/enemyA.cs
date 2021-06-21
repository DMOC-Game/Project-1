using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyA : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private float x, y;
    private Rigidbody2D rb;

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        x =   target.position.x - transform.position.x;
        x = x / (Mathf.Abs(x))*speed;
        y =  target.position.y - transform.position.y;
        y = y / (Mathf.Abs(y))*speed;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(x, y);
    }
}
