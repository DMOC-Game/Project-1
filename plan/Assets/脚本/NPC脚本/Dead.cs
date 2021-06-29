using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public float UnmatchedTime;
    private float LeftTime;
    private float alpha;
    private float alphaMutiplier = 0.99f;
    private SpriteRenderer S;
    private void Awake()
    {
        S = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        Destroy(this.gameObject, 1);
        alpha = 1;
    }
    private void Update()
    {
        S.color = new Color(1, 1, 1, alpha);
        alpha = alpha * alphaMutiplier;
        
        
    }
}
