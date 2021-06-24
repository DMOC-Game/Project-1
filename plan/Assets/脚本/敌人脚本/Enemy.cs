using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public GameObject target;
    [SerializeField] private float speed;

    [HideInInspector] public POOL bd;
    public float hurt;
    private Vector2 v;
    private Rigidbody2D rb;

    // Update is called once per frame
    private void OnEnable()
    {
        
        rb = GetComponent<Rigidbody2D>();
        this.GetComponent<property>().P = bd;
    }
    void Update()
    {
        v = (target.transform.position-transform.position).normalized;
        
        //transform.up = v; //µÐÈËÐý×ª
        v = v * speed;
        
    }

    void FixedUpdate()
    {
        rb.velocity = v;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag!="×Óµ¯")
        {
            collision.gameObject.GetComponent<property>().Hurt(hurt);
            print("PlayerDie");
        }
        
    }

}
