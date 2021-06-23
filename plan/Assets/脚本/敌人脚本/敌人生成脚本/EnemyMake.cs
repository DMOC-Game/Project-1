using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMake : MonoBehaviour
{
    
    public float refreshCD;
    
    [SerializeField] private GameObject MakeTarget;
    [SerializeField] private GameObject AttackTarget;
    [SerializeField] private int EnemyCount;
    private float startTime;
    private POOL P;
    private void Start()
    {

        P = gameObject.AddComponent<POOL>();
        var Give=MakeTarget.GetComponent<Enemy>();
        Give.bd = P;
        Give.target = AttackTarget;
        Give.transform.position = this.transform.position;
        P.GetGameObject(this.gameObject, EnemyCount,MakeTarget);
        startTime = Time.time;
    }

    private void Update()
    {
        if(Time.time>=refreshCD+startTime)
        {
            P.GetPoolOne();
            startTime = Time.time;
        }
    }
}
