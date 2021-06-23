using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public GameObject target;
    [SerializeField] private float speed;
    [HideInInspector] public POOL bd;
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
}
