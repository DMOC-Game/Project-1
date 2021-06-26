using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionChange : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.transform.localPosition = new Vector2(0, 0);
    }
    
}
