using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class WorldDataScrapper : MonoBehaviour
{

    public List<DataBase> Countries = new List<DataBase>();
    public string data = "";

    private string webLink = "https://en.wikipedia.org/wiki/Template:2019%E2%80%9320_coronavirus_pandemic_data";

    private string startString = "<tbody>";
    private string endString = "</tbody>";

    void Start()
    {
        StartCoroutine(GetRequest(webLink));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                //Debug.Log(webRequest.downloadHandler.text);

                data = webRequest.downloadHandler.text;
                LoadData(data);

            }
        }
    }

    
    private void LoadData(string data)
    {
        //Debug.Log(data.IndexOf(startString));
        //Debug.Log(data.IndexOf(endString));


        data = data.Substring(data.IndexOf(startString), data.IndexOf(endString) - data.IndexOf(startString));
        //Debug.Log(data);

        string[] lines = data.Split(new string[] { "<tr" }, StringSplitOptions.None);

        for(int k = 3; k < lines.Length; k++)
        {
            int flagIndex = 0;
            int countryIndex = 0;

            string flagLink = "";
            string countryName = "";
            string totalCases = "";
            bool flag = false;

            DataBase countryData = new DataBase();

            flagIndex = lines[k].IndexOf("src=");
            for (int i = flagIndex + 5; lines[k][i] != '"'; i++)
            {
                flagLink += lines[k][i];
            }
            //Debug.Log(flagLink);
            flagLink = flagLink.Replace("px", "0px");
            countryData.flagLink = flagLink;
            countryIndex = lines[k].IndexOf("title");
            //Debug.Log(countryIndex);
            if(flagIndex != -1)
            {
                for (int i = countryIndex; ; i++)
                {
                    if (lines[k][i] == '<')
                        break;

                    if (flag)
                    {
                        countryName += lines[k][i];
                    }
                    if (lines[k][i] == '>')
                    {
                        flag = true;
                    }

                }
                //Debug.Log(countryName);
                countryData.name = countryName;
                string[] shortLines = lines[k].Split(new string[] { "<td>" }, StringSplitOptions.None);
                int[] smalldata = new int[3];
                for (int i = 1; i < shortLines.Length - 1; i++)
                {
                    totalCases = "";
                    for (int j = 0; shortLines[i][j] != '<'; j++)
                    {
                        if (shortLines[i][j] != ',')
                        {
                            totalCases += shortLines[i][j];
                        }
                    }
                    if (totalCases != "")
                    {
                        smalldata[i - 1] = int.Parse(totalCases);

                    }
                    //Debug.Log(totalCases);

                }
                countryData.totalCases = smalldata[0];
                countryData.death = smalldata[1];
                countryData.cured = smalldata[2];

                Countries.Add(countryData);
            }
        }


    }
    public void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
