using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class States : MonoBehaviour
{
    // Start is called before the first frame update
    const string ENDPOINT = "https://api.covid19india.org/states_daily.json";
    void Start()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        UnityWebRequest request = UnityWebRequest.Get(ENDPOINT);

        yield return request.SendWebRequest();

        if(request.isNetworkError)
        {
            Debug.Log("Error");
        } else
        {
            ParseData(request.downloadHandler.text);
        }
    }

    void ParseData(string text)
    {
        Debug.Log(text);
    }
}
