using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBullet : MonoBehaviour
{

    [HideInInspector] public float OneBulleSpeed;//子弹飞行速度
    [HideInInspector] public GameObject GUN;
    [HideInInspector] public float SetTime;
    [HideInInspector] public float LeftTime;
    [HideInInspector] public float StartPotion;

    [HideInInspector] public float hurt;//子弹所造成伤害
    
    [HideInInspector] public float Accuracy;
    [HideInInspector] public float AllAccuracy;
    private Rigidbody2D rb;
    private void OnEnable()
    {
        transform.position = GUN.transform.position;
        rb = GetComponent<Rigidbody2D>();
        Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        v.z = 0;v = (v - transform.position).normalized;
        
        v = v + new Vector3(Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy),0);

        rb.velocity = v.normalized
            *OneBulleSpeed;
        LeftTime = SetTime;
    }
    private void Update()
    {
        transform.right =new Vector3(0, 0, 0);
        if (LeftTime <= 0) Destroy(this.gameObject);
        LeftTime -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);
        collision.gameObject.GetComponent<property>().Hurt(hurt);
    }
    
}
