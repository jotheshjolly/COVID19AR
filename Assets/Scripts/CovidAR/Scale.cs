using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    

    float initialFingersDistance;
    Vector3 initialScale;
    Quaternion initialRotate;
    Vector2 pos;

    // Update is called once per frame
    void Update()
    {
        if (Input.touches.Length == 2)
        {
            Touch t1 = Input.touches[0];
            Touch t2 = Input.touches[1];

            if (t1.phase == TouchPhase.Began || t2.phase == TouchPhase.Began)
            {
                initialFingersDistance = Vector2.Distance(t1.position, t2.position);
                initialScale = gameObject.transform.localScale;
            }
            else if (t1.phase == TouchPhase.Moved || t2.phase == TouchPhase.Moved)
            {
                var currentFingersDistance = Vector2.Distance(t1.position, t2.position);
                var scaleFactor = currentFingersDistance / initialFingersDistance;
                gameObject.transform.localScale = initialScale * scaleFactor;
            }
        }

        if(Input.touches.Length == 1)
        {
            Touch t1 = Input.touches[0];
            
            if(t1.phase == TouchPhase.Began)
            {
                pos = t1.position;
                initialRotate = gameObject.transform.rotation;
            }
            else if(t1.phase == TouchPhase.Moved)
            {

                var dis = (pos.x - t1.position.x) * 0.1f;
                gameObject.transform.localRotation = initialRotate * Quaternion.Euler(0, 0, dis) ;
            }
        }
    }
}
