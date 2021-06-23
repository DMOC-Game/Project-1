using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBullet : MonoBehaviour
{

    [HideInInspector] public float OneBulleSpeed;//�ӵ������ٶ�
    [HideInInspector] public Transform FiringPoint;//���䴦����
    
    
    [HideInInspector] public float hurt;//�ӵ�������˺�
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
