using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallNPC: MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float speed;

    
    public float hurt;
    private Vector2 v;
    private Rigidbody2D rb;

    // Update is called once per frame
    private void OnEnable()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        v = (GameObject.Find("player").transform.position-transform.position).normalized;
        
        //transform.up = v; //µÐÈËÐý×ª
        v = v * speed;
        
    }

    void FixedUpdate()
    {
        rb.velocity = v;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag!="BlueBullet")
        {
            collision.gameObject.GetComponent<property>().Hurt(hurt);
            
        }
        
    }

}
