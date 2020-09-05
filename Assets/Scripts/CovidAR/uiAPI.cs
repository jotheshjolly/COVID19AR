using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;
public class uiAPI : MonoBehaviour
{
    public Text totconfirmed;
    public Text totdeaths;
    public Text totrecovered;
    public Text totActive;

    public GameObject gb1;
    public GameObject gb2;


    public Text todconfirmed;
    public Text toddeaths;
    public Text todrecovered;
   



    void Start()
    {
        StartCoroutine(
            functionToCallRestAPIs(
                (JSONNode JSONresponse) =>
                {
                    functionToHandleApiResponse(JSONresponse);
                }
            )
        );

       
    }

    private IEnumerator functionToCallRestAPIs(System.Action<JSONNode> callBack)
    {
        //Get ready to call the request
        string myRequestURL = "https://corona.lmao.ninja/v2/countries/India";
        UnityWebRequest WebRequest = UnityWebRequest.Get(myRequestURL);
        WebRequest.SetRequestHeader("SomeRequestHeader", "SomeHeaderValue");

        //Send the request
        yield return WebRequest.SendWebRequest();

        //Place response into a JSONNode type
        string JSONstring = WebRequest.downloadHandler.text;
       // Debug.Log("JSON string contents --> " + JSONstring);
        JSONNode JSONnode = JSON.Parse(JSONstring);



        //Pass on the JSONNode type variable to the callback
        callBack(JSONnode);
    }

    private void functionToHandleApiResponse(JSONNode APIresponse)
    {
        // Example response -> {"version": "1.0","data": {"sampleArray": ["string value",5,{"name": "sub object"}]}}



       // Debug.Log("Total: " + APIresponse[3]["cases"].Value);
           todconfirmed.text = APIresponse["todayCases"].Value;
           toddeaths.text = APIresponse["todayDeaths"].Value;
           todrecovered.text = APIresponse["todayRecovered"].Value;





           totconfirmed.text = APIresponse["cases"].Value;
           totdeaths.text = APIresponse["deaths"].Value;
           totrecovered.text = APIresponse["recovered"].Value;

           totActive.text = APIresponse["active"].Value;
        /*  

          * {"country":"India","cases":1440371,"todayCases":4352,"deaths":32866,"todayDeaths":54,"recovered":921303,"active":486202,"critical":8944,
          * "casesPerOneMillion":1043,"deathsPerOneMillion":24,"totalTests":16806803,"testsPerOneMillion":12171},
         */

    }

    public void TodayCases()
    {
        totconfirmed.gameObject.SetActive(false);
        todconfirmed.gameObject.SetActive(true);

        totdeaths.gameObject.SetActive(false);
        toddeaths.gameObject.SetActive(true);

        totrecovered.gameObject.SetActive(false);
        todrecovered.gameObject.SetActive(true);

        gb1.SetActive(true);
        gb2.SetActive(false);
    }

    public void TotalCases()
    {
        totconfirmed.gameObject.SetActive(true);
        todconfirmed.gameObject.SetActive(false);

        totdeaths.gameObject.SetActive(true);
        toddeaths.gameObject.SetActive(false);

        totrecovered.gameObject.SetActive(true);
        todrecovered.gameObject.SetActive(false);

        gb1.SetActive(false);
        gb2.SetActive(true);
    }
}
