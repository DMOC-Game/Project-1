using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NpcGunAi : MonoBehaviour
{
    Collider2D t;
    AIDestinationSetter target;
    public float MoveRange;
    public float ShotRange;
    //public float MoveSpeed;
    LayerMask Mask;
    GunNpc G;
    private Rigidbody2D rb;
    private float LeftTime;
    private void Start()
    {
        if (gameObject.layer == 10) Mask = 1 << 9 | 1 << 6;
        else Mask = 1 << 10;
        G = gameObject.GetComponentInChildren<GunNpc>();
        //rb = gameObject.GetComponent<Rigidbody2D>();
        
        G.enabled = false;
    }
    private void Awake()
    {
        target = GetComponent<AIDestinationSetter>();
    }
    private void OnEnable()
    {
        gameObject.transform.localPosition = new Vector2(0, 0);
        LeftTime = -10;

    }
    private void Update()
    {
        if (Time.time < LeftTime + 0.1)
        {
            return;
        }
        LeftTime = Time.time;
        if (!(t = Physics2D.OverlapCircle(transform.position, MoveRange, Mask)))
        {
            return;
        }
        print(t);
        target.target = t.transform;

        if (!Physics2D.Raycast(transform.position, (target.target.position - gameObject.transform.position).normalized, ShotRange, Mask))
        {
            G.transform.right = (target.target.position - gameObject.transform.position).normalized;
            G.enabled = false;
            //rb.velocity = (target - gameObject.transform.position).normalized * MoveSpeed;
            return;
        }
        G.target = target.target.position;
        G.enabled = true;
    }
}