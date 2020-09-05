using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class BarAPI : MonoBehaviour
{

    const string ENDPOINT = "https://api.covid19india.org/csv/latest/case_time_series.csv";

    public void GetTimeData(UnityAction<List<TimeData>> callback)
    {
        StartCoroutine(GetTimeDataRoutine(callback));
    }

    IEnumerator GetTimeDataRoutine(UnityAction<List<TimeData>> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(ENDPOINT);
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log("error");
        }
        else
        {
            callback(ParseData(request.downloadHandler.text));
        }
    }
    //Date,Daily Confirmed,Total Confirmed,Daily Recovered,Total Recovered,Daily Deceased,Total Deceased

    List<TimeData> ParseData(string data)
    {
        Debug.Log(data);
        List<string> lines = data.Split('\n').ToList();
        lines.RemoveAt(0);

        List<TimeData> dataList = new List<TimeData>();

        foreach(string line in lines)
        {
            List<string> linedata = line.Split(',').ToList();
            
            TimeData timeData = new TimeData
            {
                date = linedata[0],
                confirmed = int.Parse(linedata[2]),
                recovered = int.Parse(linedata[4]),
                deaths = int.Parse(linedata[6]),
            };
            dataList.Add(timeData);
        }
        return dataList;
    }
    
}
