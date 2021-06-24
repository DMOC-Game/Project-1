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
    public float BulleDieTime;//�ӵ���ú���ʧ
    public float Accuracy;//�ӵ�ɢ��
    private float leftCd=0;
    public static int Number;
    POOL P;//����һ����ϻ
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
