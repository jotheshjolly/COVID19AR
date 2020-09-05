
using UnityEngine;

[ExecuteInEditMode]
public class InfoParent : MonoBehaviour
{
    Transform cam;
    Vector3 targetangle = Vector3.zero;
    void Start()
    {
        cam = Camera.main.transform;
    }


    void Update()
    {
        transform.LookAt(cam);
        targetangle = transform.localEulerAngles;
        targetangle.x = 0;
        targetangle.z = 0;
        transform.localEulerAngles = targetangle;
    }
}
