using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyA : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
