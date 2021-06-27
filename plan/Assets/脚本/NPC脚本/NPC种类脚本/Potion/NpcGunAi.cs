using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class NpcGunAi : MonoBehaviour
{
    [HideInInspector]public Collider2D t;
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
        target = GetComponent<AIDestinationSetter>();
        G.enabled = false;
    }
    
    private void OnEnable()
    {
        gameObject.transform.localPosition = new Vector2(0, 0);
        LeftTime = -10;

    }
    private void Update()
    {
        
        if (!(t = Physics2D.OverlapCircle(transform.position, MoveRange, Mask)))
        {
            return;
        }
        
        target.target = t.transform;
        
        if (t.transform.position.x < transform.position.x) G.GetComponent<SpriteRenderer>().flipY = true;
        else G.GetComponent<SpriteRenderer>().flipY = false;
        if (!Physics2D.Raycast(transform.position, (target.target.position - gameObject.transform.position).normalized, ShotRange, Mask))
        {
            
            
            
            G.enabled = false;
            
            return;
        }
        G.transform.right = Vector3.Lerp(G.transform.right, (target.target.position - gameObject.transform.position).normalized, 0.1f);
        G.target = target.target.position;
        G.enabled = true;
    }
}