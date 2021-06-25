using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMake: MonoBehaviour
{
    
    public float refreshCD;
    
    [SerializeField] private GameObject MakeTarget;
    [SerializeField] private GameObject AttackTarget;
    [SerializeField] private int EnemyCount;
    public int MostCount;
    private float startTime;
    private POOL P;
    private void Start()
    {

        P = gameObject.AddComponent<POOL>();
        var Give=MakeTarget.GetComponent<SmallNPC>();
        Give.bd = P;
        Give.target = AttackTarget;
        Give.transform.position = this.transform.position;
        P.GetGameObject(this.gameObject, EnemyCount,MakeTarget);
        startTime = Time.time;
    }

    private void Update()
    {
        if(MostCount<=0)
        {
            startTime = Time.time;
            return;
        }
        if(Time.time>=refreshCD+startTime)
        {
            MostCount--;
            P.GetPoolOne();
            startTime = Time.time;
        }
    }
}
