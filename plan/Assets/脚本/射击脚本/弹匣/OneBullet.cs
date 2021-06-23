using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBullet : MonoBehaviour
{

    [HideInInspector] public float OneBulleSpeed;//子弹飞行速度
    [HideInInspector] public Transform FiringPoint;//发射处坐标
    
    
    [HideInInspector] public float hurt;//子弹所造成伤害
    [HideInInspector] public POOL bd;
    private Rigidbody2D rb;
    private void OnEnable()
    {
        
        FiringPoint = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.position = FiringPoint.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (Camera.main.ScreenToWorldPoint(Input.mousePosition)-FiringPoint.position).normalized
            *OneBulleSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        bd.ReturnPool(gameObject);
        collision.gameObject.GetComponent<property>().Hurt(hurt);
    }
    
}
