using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class barBehaviour : MonoBehaviour
{
    const float SPEED = 6f;
    Vector3 scale;

    void Start()
    {
        scale = transform.localScale;
        
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, scale, Time.deltaTime * SPEED);
    }

    public void SetScale(float y)
    {
        scale.y = y;
    }
}
