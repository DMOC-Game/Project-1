using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotting : MonoBehaviour
{
    [SerializeField]public GameObject BulletStyle;//接收图片
    [SerializeField]public int ShottingNumberPool;//弹匣池容量
    [SerializeField] public int ShottingCount;//一次射击多少发装弹(还未启用)
    [SerializeField] public float ShottingCD;//射击间隔
    [SerializeField] public float FlySpeed;//射击速度
    [SerializeField] public float hurt;//每发子弹造成伤害
    private float leftCd=0;
    private POOL BD;//创建一个弹匣
    void Awake()
    {
        var GiveBull= BulletStyle.GetComponent<OneBullet>();
        GiveBull.OneBulleSpeed = FlySpeed;
        GiveBull.hurt = hurt;
        BD = new POOL(gameObject, ShottingNumberPool, BulletStyle);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            leftCd -= Time.deltaTime;
            if(leftCd<=0)
            {
                BD.GetPoolOne();
                leftCd = ShottingCD;
            }
        }
    }
}
