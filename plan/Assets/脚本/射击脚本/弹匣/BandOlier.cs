using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandOlier : MonoBehaviour
{
    private Queue<GameObject> Pool;
    private int BulletCount;
    private GameObject Bullet;
    private GameObject Father;
    public BandOlier(GameObject father,int Count,GameObject Style)
    {
        Pool = new Queue<GameObject>();
        BulletCount = Count;
        Bullet = Style;
        Father = father;
        FillBandOlier();
    }



    private void Awake()
    {
        
    }
    void FillBandOlier()
    {
        for(int i=0;i<BulletCount;i++)
        {
            GameObject NewBullet = Instantiate(Bullet);
            NewBullet.transform.SetParent(Father.transform);
            ReturnPool(NewBullet);
        }
    }
    public void ReturnPool(GameObject NewBullet)
    {
        NewBullet.SetActive(false);
        Pool.Enqueue(NewBullet);
    }

    public GameObject GetPoolOne()
    {
        if (Pool.Count == 0) FillBandOlier();
        GameObject outBullet = Pool.Dequeue();
        outBullet.SetActive(true);
        return outBullet;
    }
}
