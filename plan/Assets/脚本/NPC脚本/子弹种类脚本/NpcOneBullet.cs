using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcOneBullet : MonoBehaviour
{
    [HideInInspector] public float OneBulleSpeed;//�ӵ������ٶ�
    [HideInInspector] public GameObject GUN;
    [HideInInspector] public float SetTime;
    [HideInInspector] public float LeftTime;
    [HideInInspector] public float StartPotion;

    [HideInInspector] public float hurt;//�ӵ�������˺�
    [HideInInspector] public POOL bd;
    [HideInInspector] public float Accuracy;
    [HideInInspector] public float AllAccuracy;
    private Rigidbody2D rb;
    private void OnEnable()
    {
        transform.position = GUN.transform.position;
        rb = GetComponent<Rigidbody2D>();
        Vector3 v = GUN.GetComponent<GunNpc>().NpcTarget;
        v.z = 0; v = (v - transform.position).normalized;

        v = v + new Vector3(Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy), 0);

        rb.velocity = v.normalized
            * OneBulleSpeed;
        LeftTime = SetTime;
    }
    private void Update()
    {
        if (LeftTime <= 0) bd.ReturnPool(this.gameObject);
        LeftTime -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        bd.ReturnPool(gameObject);
        collision.gameObject.GetComponent<property>().Hurt(hurt);
    }



}
