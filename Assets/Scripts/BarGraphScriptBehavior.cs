using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarGraphScriptBehavior : MonoBehaviour
{
    private const string URL = "https://corona.lmao.ninja/v2/countries?sort=cases";

    public List<float> bars = new List<float>();
    public List<GameObject> bar = new List<GameObject>();
    public List<GameObject> names = new List<GameObject>();

    public GameObject gb;


    void Start()
    {
        var g = Instantiate(gb);
        WWW request = new WWW(URL);
        StartCoroutine(OnResponse(request));
        bars[0] = GameObject.Find("1st").transform.position.y;
        bars[0] = GameObject.Find("2nd").transform.position.y;
        bars[0] = GameObject.Find("3rd").transform.position.y;
        bars[0] = GameObject.Find("4th").transform.position.y;
        bars[0] = GameObject.Find("5th").transform.position.y;
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;
        if (req.isDone)
        {
            var data = JsonUtility.FromJson<RootObject>("{ \"countries\": " + req.text + "}");

            for (int i = 0; i < 5; i++)
            {
                if (data.countries[i].country.ToLower() != "world")
                {
                    bars[i] = data.countries[i].cases;
                    var div = bars[i] / 1000000;
                    float textpos = div / 1.2f;
                    bar[i].transform.localScale = new Vector3(1f, div, 1f);


                    TextMeshPro txt = names[i].transform.Find("name").GetComponent<TextMeshPro>();
                    txt.text = data.countries[i].country;

                    TextMeshPro txtcases = names[i].transform.Find("cases").GetComponent<TextMeshPro>();
                    txtcases.text = data.countries[i].cases.ToString();
                    names[i].transform.Find("cases").localPosition = new Vector3(0f, textpos, 0f);
                }
            }

       

        }

        
        

    }




    [System.Serializable]
    public class RootObject
    {
        public List<UserObject> countries;
    }
}
