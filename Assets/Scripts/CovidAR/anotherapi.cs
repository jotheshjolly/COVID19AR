using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;
public class anotherapi : MonoBehaviour
{
    public TextMeshPro totconfirmed;
    public TextMeshPro totdeaths;
    public TextMeshPro totrecovered;

   

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
        string myRequestURL = "https://api.rootnet.in/covid19-in/stats/latest";
        UnityWebRequest WebRequest = UnityWebRequest.Get(myRequestURL);
        WebRequest.SetRequestHeader("SomeRequestHeader", "SomeHeaderValue");

        //Send the request
        yield return WebRequest.SendWebRequest();

        //Place response into a JSONNode type
        string JSONstring = WebRequest.downloadHandler.text;
        Debug.Log("JSON string contents --> " + JSONstring);
        JSONNode JSONnode = JSON.Parse(JSONstring);



        //Pass on the JSONNode type variable to the callback
        callBack(JSONnode);
    }

    private void functionToHandleApiResponse(JSONNode APIresponse)
    {
        // Example response -> {"version": "1.0","data": {"sampleArray": ["string value",5,{"name": "sub object"}]}}

        Debug.Log("Total: " + APIresponse["data"]["summary"][0].Value);
        totconfirmed.text = APIresponse["data"]["summary"][0].Value;
        totdeaths.text = APIresponse["data"]["summary"][4].Value;
        totrecovered.text = APIresponse["data"]["summary"][3].Value;

        

    }
}
