using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POOL: MonoBehaviour
{
    private Queue<GameObject> Pool;
    private int BulletCount;
    private GameObject Bullet;
    private GameObject Father;
    public POOL(GameObject father,int Count,GameObject Style)
    {
        Pool = new Queue<GameObject>();
        BulletCount = Count;
        Bullet = Style;
        Father = father;
        FillPOOL();
    }



    
    void FillPOOL()
    {
        for(int i=0;i<BulletCount;i++)
        {
            GameObject NewBullet = Instantiate(Bullet);
            NewBullet.transform.SetParent(Father.transform);
            NewBullet.GetComponent<OneBullet>().bd = this;
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
        if (Pool.Count == 0) FillPOOL();
        GameObject outBullet = Pool.Dequeue();
        outBullet.SetActive(true);
        return outBullet;
    }
}
