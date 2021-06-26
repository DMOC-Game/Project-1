using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunNpc : MonoBehaviour
{
    public GameObject BulletStyle;//����ͼƬ
    public int ShottingNumberPool;//��ϻ������
    public int ShottingCount;//һ��������ٷ�װ��(��δ����)
    public float ShottingCD;//������
    public float FlySpeed;//����ٶ�
    public float hurt;//ÿ���ӵ�����˺�
    public float OneShottingBullet;//һ��������ٷ��ӵ�
    public int ShottingRoundCount;//�ܹ��������
    public float ShottingRoundTime;//һ�����ʱ����
    public float Range;//�ӵ���ú���ʧ
    public float Accuracy;//�ӵ�ɢ��
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
