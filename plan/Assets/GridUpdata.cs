using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GridUpdata : MonoBehaviour
{
    public float LastTime;
    // Start is called before the first frame update
    void Start()
    {
        LastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastTime > 1)
        {
            AstarPath.active.Scan();
            print("Scan");
            LastTime = Time.time;
        }
    }
}
