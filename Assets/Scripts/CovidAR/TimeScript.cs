using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public TextMeshPro txt;
    void Start()
    {
        PlayerPrefs.SetString("date time", System.DateTime.Now.ToString("dd/MM/yyyy"));
        
        txt.text = PlayerPrefs.GetString("date time");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
