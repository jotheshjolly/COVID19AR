using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WorldDatamapper : MonoBehaviour
{
    public GameObject Scrapper;
    private DataBase[] data;
    public GameObject WorldMap;
    public GameObject infoFlag;
    public string countryName;
    public List<Text> details;
    public GameObject flag;


    private Camera cam;
    private GameObject country;
    private GameObject prevCountry;
    private GameObject[] planes;

    private bool execute = false;

    private void Start()
    {
        Scrapper = GameObject.Find("WorldDataScrapper");
        details[0] = GameObject.Find("CountryName").GetComponent<Text>();
        Debug.Log(details[0].text);
        details[1] = GameObject.Find("ConfirmedCases").GetComponent<Text>();
        details[2] = GameObject.Find("ActiveCases").GetComponent<Text>();
        details[3] = GameObject.Find("RecoveredCases").GetComponent<Text>();
        details[4] = GameObject.Find("DeceasedCases").GetComponent<Text>();
        flag = GameObject.Find("CountryFlag");
        cam = Camera.main;
        Invoke("LoadedData", 3.0f);
    }

    private void LoadedData()
    {
        data = Scrapper.GetComponent<WorldDataScrapper>().Countries.ToArray();
        Debug.Log(data.Length);
        execute = true;
        
    }
    private void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
       /* planes = GameObject.FindGameObjectsWithTag("plane");
        foreach (var plane in planes)
        {
            Destroy(plane);
        } */
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && execute)
        {
            countryName = hit.transform.name;

            if (prevCountry != null && prevCountry.name != countryName)
            {
                //Destroy(flag);
                //prevCountry.transform.position = prevCountry.transform.position - new Vector3(0, 0.2f * gameObject.transform.localScale.y, 0);
                prevCountry.GetComponent<Renderer>().material.color = new Color(0.7f, 1, 0.7f);

            }
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].name == countryName)
                { 
                    country = GameObject.Find(countryName);

                    country.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 0.3f);
                    StartCoroutine(GetTexture(data[i].flagLink));
                    details[0].text = data[i].name;
                    details[1].text = "Confirmed - " + data[i].totalCases.ToString();
                    details[2].text = "Active - " + (data[i].totalCases - data[i].cured - data[i].death).ToString();
                    details[3].text = "Recovered - " + data[i].cured.ToString();
                    details[4].text = "Deceased - " + data[i].death.ToString();
                    prevCountry = country;
                    


                }

            }
        }



        
    }


    IEnumerator GetTexture(string flaglink)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(flaglink);
        yield return www.SendWebRequest();

        Texture2D myTexture = DownloadHandlerTexture.GetContent(www);
        flag.GetComponent<Image>().sprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
    }
}

