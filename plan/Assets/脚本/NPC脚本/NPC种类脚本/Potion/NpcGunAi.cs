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
    LayerMask Mask1;
    LayerMask Mask2;
    Collider C;
    GunNpc G;
    private Rigidbody2D rb;
    private float LeftTime;
    private void Start()
    {
        if (gameObject.layer == 10)
        {
            Mask1 = 1 << 9 | 1 << 6;
            

        }
        else
        { 
            Mask1 = 1 << 10;
            
        }
        Mask2 = 1 << 17;
        G = gameObject.GetComponentInChildren<GunNpc>();
        //rb = gameObject.GetComponent<Rigidbody2D>();
        target = GetComponent<AIDestinationSetter>();
        G.enabled = false;
    }
    
    private void OnEnable()
    {
        gameObject.transform.localPosition = new Vector2(Random.Range(-3,3), Random.Range(-3,3));
        LeftTime = -10;

    }
    private void Update()
    {
        if (Time.time > LeftTime + 0.1)
        {
            LeftTime = Time.time;
            if (!(t = Physics2D.OverlapCircle(transform.position, MoveRange, Mask1)))
            {
                return;
            }
        }
        target.target = t.transform;
        
        if (t.transform.position.x < transform.position.x) G.GetComponent<SpriteRenderer>().flipY = true;
        else G.GetComponent<SpriteRenderer>().flipY = false;
        if (!Physics2D.Raycast(transform.position, (target.target.position - gameObject.transform.position).normalized, ShotRange, Mask1) ||
            Physics2D.Raycast(transform.position, (target.target.position - gameObject.transform.position).normalized, ShotRange, Mask2))
        {                                 
            G.enabled = false;           
            return;
        }
        G.transform.right = Vector3.Lerp(G.transform.right, (target.target.position - gameObject.transform.position).normalized, 0.1f);
        G.target = target.target.position;
        G.enabled = true;
    }
}