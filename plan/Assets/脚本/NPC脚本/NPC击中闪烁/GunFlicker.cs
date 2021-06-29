using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlicker : MonoBehaviour
{
    [HideInInspector]public float flickerTime;
    private float LeftTime;
    private float alpha;
    private float alphaMutiplier = 0.9f;
    private SpriteRenderer S;
    // Start is called before the first frame update
    private void OnEnable()
    {
        LeftTime = flickerTime;
        S = this.gameObject.GetComponent<SpriteRenderer>();
        alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftTime <= 0)
        {
            gameObject.GetComponent<GunFlicker>().enabled = false;
            alpha = 1;
            S.color = new Color(1, 1, 1, 1);
        }
        LeftTime -= Time.deltaTime;
        alpha = alpha * alphaMutiplier;
        if (alpha <= 0.1) alpha = 1;
        S.color = new Color(1, 1, 1, alpha);
    }
}
