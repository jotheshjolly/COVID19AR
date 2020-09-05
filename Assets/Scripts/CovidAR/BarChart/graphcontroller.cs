using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class graphcontroller : MonoBehaviour
{
    public float WaitTime = 0.2f;
    public float BarScale = 10000;

    [SerializeField]
    BarAPI api;

    [SerializeField]
    TextMeshPro title;

    [SerializeField]
    List<barBehaviour> bars = new List<barBehaviour>();

    
    void Start()
    {
        api.GetTimeData(OnDataReceived);
    }

    void OnDataReceived(List<TimeData> dataList)
    {
        StartCoroutine(CycleDataRoutine(dataList));
    }

    IEnumerator CycleDataRoutine(List<TimeData> dataList)
    {
        while (true)
        {
            foreach (TimeData data in dataList)
            {
                title.text = data.date;
                bars[0].SetScale(data.confirmed / BarScale);
                bars[1].SetScale(data.deaths / BarScale);
                bars[2].SetScale(data.recovered / BarScale);
                yield return new WaitForSeconds(WaitTime);
            }
        }
    }
}
