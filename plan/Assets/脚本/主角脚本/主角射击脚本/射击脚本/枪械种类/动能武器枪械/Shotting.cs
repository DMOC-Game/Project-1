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
    public float OneShottingBullet;//一轮射击多少发子弹
    public int ShottingRoundCount;//总共射击几轮
    public float ShottingRoundTime;//一轮射击时间间隔
    public float Range;//子弹多久后消失
    public float Accuracy;//子弹散射
    private float leftCd=0;
    public static int Number;
    private bool ShottingNow;
    private int RoundCount;
    private float RoundTime;
    POOL P;//创建一个弹匣
    void Start()
    {
        P=gameObject.AddComponent<POOL>();
        OneBullet GiveBull= BulletStyle.GetComponent<OneBullet>();
        if(transform.parent!=null) transform.position = transform.parent.position;
        GiveBull.OneBulleSpeed = FlySpeed;
        GiveBull.hurt = hurt;
        GiveBull.GUN = this.gameObject;
        GiveBull.bd = P;
        GiveBull.SetTime = Range/FlySpeed;
        GiveBull.Accuracy = Accuracy;
        GiveBull.AllAccuracy = Accuracy* OneShottingBullet/2;
        
        P.GetGameObject(this.gameObject, ShottingNumberPool,BulletStyle);
    }
    private void OnEnable()
    {
        ShottingNow = false;
        RoundTime = ShottingRoundTime;
    }
    void Update()
    {
        if(ShottingNow)
        {
            RoundTime -= Time.deltaTime;
            if (RoundTime > 0) return;
            if (--RoundCount < 0)
            {
                ShottingNow = false;
                return;
            }
            RoundTime = ShottingRoundTime;
            for (int i = 0; i < OneShottingBullet; i++)
            {
                Number = i;
                P.GetPoolOne();
            }          
            
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {    
            if(leftCd<=0)
            {
                ShottingNow = true;
                RoundCount = ShottingRoundCount;
                RoundTime = ShottingRoundTime;
                leftCd = ShottingCD;
            }
        }
        leftCd -= Time.deltaTime;
    }
}
