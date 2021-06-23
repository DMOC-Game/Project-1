using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotting : MonoBehaviour
{
    public GameObject BulletStyle;//接收图片
    public int ShottingNumberPool;//弹匣池容量
    public int ShottingCount;//一次射击多少发装弹(还未启用)
    public float ShottingCD;//射击间隔
    public float FlySpeed;//射击速度
    public float hurt;//每发子弹造成伤害
    public float OneShottingBullet;//一次射击多少发子弹
    private float leftCd=0;
    POOL P;//创建一个弹匣
    void Start()
    {
        P=gameObject.AddComponent<POOL>();
        var GiveBull= BulletStyle.GetComponent<OneBullet>();

        GiveBull.OneBulleSpeed = FlySpeed;
        GiveBull.hurt = hurt;
        GiveBull.GUN = this.gameObject;
        GiveBull.bd = P;
        P.GetGameObject(this.gameObject, ShottingNumberPool,BulletStyle);
        
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            leftCd -= Time.deltaTime;
            if(leftCd<=0)
            {
                for(int i=0;i<OneShottingBullet;i++)P.GetPoolOne();
                leftCd = ShottingCD;
            }
        }
    }
}
