using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;
    [SerializeField] public GameObject shadowTarger;
    [SerializeField] public int ShadowCount;
    private Queue<GameObject>Pool=new Queue<GameObject>();
    private void Awake()
    {
        instance = this;
        FillPool();
    }

    public void FillPool()
    {
        for(int i=0;i<ShadowCount;i++)
        {
            GameObject newShadow = Instantiate(shadowTarger);
            newShadow.transform.SetParent(transform);
            ReturnPool(newShadow);
        }
    }
    public void ReturnPool(GameObject obj)
    {
        obj.SetActive(false);
        Pool.Enqueue(obj);
    }

    public GameObject GetPoolOne()
    {
        if (Pool.Count == 0) FillPool();
        GameObject outShadow = Pool.Dequeue();
        outShadow.SetActive(true);
        
        return outShadow;
    }
}
