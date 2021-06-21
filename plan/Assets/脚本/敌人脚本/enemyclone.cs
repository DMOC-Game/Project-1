using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyclone : MonoBehaviour
{
    private int sum;
    [SerializeField] private GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        sum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(sum>=30)
        {
            Instantiate(g, transform.position, transform.rotation);
            sum = 0;
        }
    }
    private void FixedUpdate()
    {
        sum = Mathf.Clamp(++sum, 0, 30);

    }
}
