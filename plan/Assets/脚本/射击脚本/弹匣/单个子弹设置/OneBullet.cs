using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBullet : MonoBehaviour
{
    [SerializeField]public float OneBulleSpeed;//子弹飞行速度
    public Transform FiringPoint;//发射处坐标
    public Rigidbody2D rb;
    private void OnEnable()
    {
        FiringPoint = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.position = FiringPoint.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (Camera.main.ScreenToWorldPoint(Input.mousePosition)-FiringPoint.position).normalized
            *OneBulleSpeed;
    }
    
}
