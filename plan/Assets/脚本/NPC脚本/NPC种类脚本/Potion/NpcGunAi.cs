using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcGunAi : MonoBehaviour
{
    Collider2D t;
    Vector3 target;
    public float MoveRange;
    public float ShotRange;
    public float MoveSpeed;
    LayerMask Mask;
    GunNpc G;
    private Rigidbody2D rb;
    private void Start()
    {
        if (gameObject.layer == 10) Mask = 1 << 6 | 1 << 9;
        else Mask = 1 << 10;
        G = gameObject.GetComponentInChildren<GunNpc>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        G.enabled = false;
    }
    private void OnEnable()
    {
        gameObject.transform.localPosition = new Vector2(0, 0);
        
    }
    private void Update()
    {
        if (!(t = Physics2D.OverlapCircle(transform.position, MoveRange, Mask)))
        {           
            return;
        }
        target = t.transform.position;
        G.transform.right =Vector3.Lerp(G.transform.right,(target - gameObject.transform.position).normalized,5*Time.deltaTime);       
        if (!Physics2D.Raycast(transform.position, G.transform.right, ShotRange, Mask))
        {
            
            G.enabled = false;
            rb.velocity = (target - gameObject.transform.position).normalized * MoveSpeed;
            return;
        }
        G.target = target;
        G.enabled = true;                    
    }
}
