using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlacementObject : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    UIManager manager = new UIManager();

    public GameObject placementObject;
    private GameObject instantiatedRocket;

    private List<ARRaycastHit> arRaycastHits = new List<ARRaycastHit>();

    private bool objectCreated = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    if (!objectCreated)
                    {
                       
                        if (raycastManager.Raycast(touch.position, arRaycastHits))
                        {
                            var pose = arRaycastHits[0].pose;
                            CreateObject(pose.position);
                            TogglePlaneDetection(false);
                            return;
                        }
                    }
                }
            }
        }
    }

    private void CreateObject(Vector3 position)
    {
        instantiatedRocket = Instantiate(placementObject, position, Quaternion.identity);
        objectCreated = true;
        manager.PlacedObject();
    }


    private void TogglePlaneDetection(bool state)
    {
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(state);
        }
        planeManager.enabled = state;
    }

}
