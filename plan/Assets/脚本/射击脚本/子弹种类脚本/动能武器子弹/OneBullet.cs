using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBullet : MonoBehaviour
{

    [HideInInspector] public float OneBulleSpeed;//子弹飞行速度
    [HideInInspector] public GameObject GUN;
    
    
    [HideInInspector] public float hurt;//子弹所造成伤害
    [HideInInspector] public POOL bd;
    private Rigidbody2D rb;
    private void OnEnable()
    {
        transform.position = GUN.transform.position;
        rb = GetComponent<Rigidbody2D>();
        Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        v.z = 0;
        rb.velocity = (v-GUN.transform.position).normalized
            *OneBulleSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        bd.ReturnPool(gameObject);
        collision.gameObject.GetComponent<property>().Hurt(hurt);
    }
    
}
