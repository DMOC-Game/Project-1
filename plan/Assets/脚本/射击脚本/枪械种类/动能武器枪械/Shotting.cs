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
    public float BulleDieTime;//子弹多久后消失
    public float Accuracy;//子弹散射
    private float leftCd=0;
    public static int Number;
    POOL P;//创建一个弹匣
    void Start()
    {
        P=gameObject.AddComponent<POOL>();
        var GiveBull= BulletStyle.GetComponent<OneBullet>();
        if(transform.parent!=null) transform.position = transform.parent.position;
        GiveBull.OneBulleSpeed = FlySpeed;
        GiveBull.hurt = hurt;
        GiveBull.GUN = this.gameObject;
        GiveBull.bd = P;
        GiveBull.SetTime = BulleDieTime;
        GiveBull.Accuracy = Accuracy;
        GiveBull.AllAccuracy = Accuracy* OneShottingBullet/2;
        
        P.GetGameObject(this.gameObject, ShottingNumberPool,BulletStyle);
        
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            leftCd -= Time.deltaTime;
            if(leftCd<=0)
            {
                
                for (int i=0;i<OneShottingBullet;i++)
                {
                    Number = i;
                    P.GetPoolOne();
                }
                leftCd = ShottingCD;
            }
        }
    }
}
