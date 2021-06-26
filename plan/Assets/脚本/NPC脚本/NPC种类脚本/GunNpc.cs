using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunNpc : MonoBehaviour
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
    [HideInInspector] public Vector3 target;
    private float leftCd = 0;
    public static int Number;
    private bool ShottingNow;
    private int RoundCount;
    private float RoundTime;
    private SpriteRenderer me;
    [HideInInspector] public POOL P;
    NpcOneBullet GiveBull;
    void Start()
    {


        GiveBull = BulletStyle.GetComponent<NpcOneBullet>();
        transform.position = transform.parent.position;
        GiveBull.OneBulleSpeed = FlySpeed;
        GiveBull.hurt = hurt;
        GiveBull.GUN = this.gameObject;
        
        GiveBull.SetTime = Range / FlySpeed;
        GiveBull.Accuracy = Accuracy;
        GiveBull.AllAccuracy = Accuracy * OneShottingBullet / 2;
        me=GetComponent<SpriteRenderer>();
        
    }
    
    void Update()
    {
        transform.right = (target-gameObject.transform.position).normalized;
        if (target.x > transform.parent.position.x) me.flipY = false;
        else me.flipY = true;
        if (ShottingNow)
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
                GiveBull.transform.position = transform.position;
                Instantiate(GiveBull);
            }

            return;
        }
        
        if (leftCd <= 0)
        {
            ShottingNow = true;
            RoundCount = ShottingRoundCount;
            RoundTime = ShottingRoundTime;
            leftCd = ShottingCD;
        }
     
        leftCd -= Time.deltaTime;
    }
}
