using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensorLength = 5.0f;
    public float turnValue = 0.0f;
    public float speed = 1f;
    public float directionValue = 1.0f;
    public float turnspeed = 5.0f;
    Renderer ren;
    Collider myCollider;
    void Start()
    {
        myCollider = transform.GetComponent<Collider>();

        ren = transform.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        int flag = 0;

        if (Physics.Raycast(transform.position, transform.right, out hit, (sensorLength + transform.localScale.x)))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }


            turnValue -= 1;
            flag++;
        }

        if (Physics.Raycast(transform.position, -transform.right, out hit, (sensorLength + transform.localScale.x)))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }
            
            turnValue += 1;
            flag++;
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, (sensorLength + transform.localScale.z)))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }

            if(directionValue == 1.0f)
            {
                directionValue = -1;
            }
            flag++;

        }

        if (Physics.Raycast(transform.position, -transform.forward, out hit, (sensorLength + transform.localScale.z)))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }

            if (directionValue == -1.0f)
            {
                directionValue = 1;
            }
            flag++;
        }
        if(flag == 0)
        {
            turnValue = 0;
        }

        transform.Rotate(Vector3.up * (turnspeed * turnValue) * Time.deltaTime);

        transform.position += transform.forward * (speed * directionValue) * Time.deltaTime;
        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * (sensorLength + transform.localScale.z));
        Gizmos.DrawRay(transform.position, -transform.forward * (sensorLength + transform.localScale.z));
        Gizmos.DrawRay(transform.position, transform.right * (sensorLength + transform.localScale.x));
        Gizmos.DrawRay(transform.position, -transform.right * (sensorLength + transform.localScale.x));
    }


}
