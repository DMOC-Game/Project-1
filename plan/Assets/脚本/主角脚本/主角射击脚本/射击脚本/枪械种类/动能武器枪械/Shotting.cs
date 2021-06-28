using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shotting : MonoBehaviour
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
    private float leftCd=0;
    public static int Number;
    private bool ShottingNow;
    private int RoundCount;
    private float RoundTime;
    POOL P;//����һ����ϻ
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
