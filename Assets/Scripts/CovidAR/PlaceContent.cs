using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceContent : MonoBehaviour
{
    public ARRaycastManager raycastmanager;
    public GraphicRaycaster raycaster;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !IsClickedOverUI())
        {
            List<ARRaycastHit> hitpoints = new List<ARRaycastHit>();
            raycastmanager.Raycast(Input.mousePosition, hitpoints, TrackableType.Planes);

            if(hitpoints.Count > 0)
            {
                Pose pose = hitpoints[0].pose;
                transform.rotation = pose.rotation;
                transform.position = pose.position;
            }
        }
    }

    bool IsClickedOverUI()
    {
        PointerEventData data = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(data, results);
        return results.Count > 0;
    }
}
