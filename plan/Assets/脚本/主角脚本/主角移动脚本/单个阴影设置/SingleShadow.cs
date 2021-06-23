using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShadow : MonoBehaviour
{

    private Transform target;
    private SpriteRenderer thisSprite;
    private SpriteRenderer targetSprite;
    [Header("ʱ�����")]
    public float activeTime;//��ʾʱ��



    private float activeStart;//��ʼ��ʾ��ʱ���

    [Header("͸���ȿ���")]
    
    public float alphaSet;
    public float alphaMutiplier;

    private float alpha;
    private void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        targetSprite = target.GetComponent<SpriteRenderer>();
        alpha = alphaSet;
        
        thisSprite.sprite = targetSprite.sprite;

        transform.localPosition = target.localPosition;
        transform.position = target.position;
        transform.rotation = target.rotation;

        activeStart = Time.time;
    }
    void Update()
    {
        alpha*= alphaMutiplier;
        
        thisSprite.color = new Color(0.5f, 0.5f, 1, alpha);
        if(Time.time>=activeStart+activeTime)
        {
            ShadowPool.instance.ReturnPool(this.gameObject);
        }
    }
}
