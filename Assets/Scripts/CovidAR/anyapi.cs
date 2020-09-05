using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;

public class anyapi : MonoBehaviour
{
    

    public TextMeshPro mhconfirmedText;
    public TextMeshPro mhdeathText;
    public TextMeshPro mhrecovered;
    public TextMeshPro mhactive;

    public TextMeshPro gjconfirmedText;
    public TextMeshPro gjdeathText;
    public TextMeshPro gjrecovered;
    public TextMeshPro gjactive;

    public TextMeshPro dlconfirmedText;
    public TextMeshPro dldeathText;
    public TextMeshPro dlrecovered;
    public TextMeshPro dlactive;

    public TextMeshPro rjconfirmedText;
    public TextMeshPro rjdeathText;
    public TextMeshPro rjrecovered;
    public TextMeshPro rjactive;

    public TextMeshPro tnconfirmedText;
    public TextMeshPro tndeathText;
    public TextMeshPro tnrecovered;
    public TextMeshPro tnactive;

    public TextMeshPro mpconfirmedText;
    public TextMeshPro mpdeathText;
    public TextMeshPro mprecovered;
    public TextMeshPro mpactive;

    public TextMeshPro upconfirmedText;
    public TextMeshPro updeathText;
    public TextMeshPro uprecovered;
    public TextMeshPro upactive;

    public TextMeshPro apconfirmedText;
    public TextMeshPro apdeathText;
    public TextMeshPro aprecovered;
    public TextMeshPro apactive;

    public TextMeshPro tgconfirmedText;
    public TextMeshPro tgdeathText;
    public TextMeshPro tgrecovered;
    public TextMeshPro tgactive;

    public TextMeshPro wbconfirmedText;
    public TextMeshPro wbdeathText;
    public TextMeshPro wbrecovered;
    public TextMeshPro wbactive;

    public TextMeshPro jkconfirmedText;
    public TextMeshPro jkdeathText;
    public TextMeshPro jkrecovered;
    public TextMeshPro jkactive;

    public TextMeshPro kaconfirmedText;
    public TextMeshPro kadeathText;
    public TextMeshPro karecovered;
    public TextMeshPro kaactive;

    public TextMeshPro klconfirmedText;
    public TextMeshPro kldeathText;
    public TextMeshPro klrecovered;
    public TextMeshPro klactive;

    public TextMeshPro pbconfirmedText;
    public TextMeshPro pbdeathText;
    public TextMeshPro pbrecovered;
    public TextMeshPro pbactive;

    public TextMeshPro hrconfirmedText;
    public TextMeshPro hrdeathText;
    public TextMeshPro hrrecovered;
    public TextMeshPro hractive;

    public TextMeshPro brconfirmedText;
    public TextMeshPro brdeathText;
    public TextMeshPro brrecovered;
    public TextMeshPro bractive;

    public TextMeshPro odconfirmedText;
    public TextMeshPro oddeathText;
    public TextMeshPro odrecovered;
    public TextMeshPro odactive;

    public TextMeshPro jhconfirmedText;
    public TextMeshPro jhdeathText;
    public TextMeshPro jhrecovered;
    public TextMeshPro jhactive;

    public TextMeshPro utconfirmedText;
    public TextMeshPro utdeathText;
    public TextMeshPro utrecovered;
    public TextMeshPro utactive;

    public TextMeshPro hpconfirmedText;
    public TextMeshPro hpdeathText;
    public TextMeshPro hprecovered;
    public TextMeshPro hpactive;


    public TextMeshPro asconfirmedText;
    public TextMeshPro asdeathText;
    public TextMeshPro asrecovered;
    public TextMeshPro asactive;

    public TextMeshPro chconfirmedText;
    public TextMeshPro chdeathText;
    public TextMeshPro chrecovered;
    public TextMeshPro chactive;

    public TextMeshPro laconfirmedText;
    public TextMeshPro ladeathText;
    public TextMeshPro larecovered;
    public TextMeshPro laactive;

    public TextMeshPro mlconfirmedText;
    public TextMeshPro mldeathText;
    public TextMeshPro mlrecovered;
    public TextMeshPro mlactive;

    public TextMeshPro pyconfirmedText;
    public TextMeshPro pydeathText;
    public TextMeshPro pyrecovered;
    public TextMeshPro pyactive;

    public TextMeshPro gaconfirmedText;
    public TextMeshPro gadeathText;
    public TextMeshPro garecovered;
    public TextMeshPro gaactive;

    public TextMeshPro mnconfirmedText;
    public TextMeshPro mndeathText;
    public TextMeshPro mnrecovered;
    public TextMeshPro mnactive;

    public TextMeshPro trconfirmedText;
    public TextMeshPro trdeathText;
    public TextMeshPro trrecovered;
    public TextMeshPro tractive;

    public TextMeshPro mzconfirmedText;
    public TextMeshPro mzdeathText;
    public TextMeshPro mzrecovered;
    public TextMeshPro mzactive;

    public TextMeshPro arconfirmedText;
    public TextMeshPro ardeathText;
    public TextMeshPro arrecovered;
    public TextMeshPro aractive;

    public TextMeshPro nlconfirmedText;
    public TextMeshPro nldeathText;
    public TextMeshPro nlrecovered;
    public TextMeshPro nlactive;


    public TextMeshPro skconfirmedText;
    public TextMeshPro skdeathText;
    public TextMeshPro skrecovered;
    public TextMeshPro skactive;

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
        string myRequestURL = "https://api.rootnet.in/covid19-in/unofficial/covid19india.org/statewise";
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
        
        
       

        mhconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][0]["confirmed"].Value;
        mhdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][0]["deaths"].Value;
        mhrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][0]["recovered"].Value;
        mhactive.text = "Active: " + APIresponse["data"]["statewise"][0]["active"].Value;

        gjconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][1]["confirmed"].Value;
        gjdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][1]["deaths"].Value;
        gjrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][1]["recovered"].Value;
        gjactive.text = "Active: " + APIresponse["data"]["statewise"][1]["active"].Value;

        dlconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][2]["confirmed"].Value;
        dldeathText.text = "Deaths: " + APIresponse["data"]["statewise"][2]["deaths"].Value;
        dlrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][2]["recovered"].Value;
        dlactive.text = "Active: " + APIresponse["data"]["statewise"][2]["active"].Value;

        rjconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][3]["confirmed"].Value;
        rjdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][3]["deaths"].Value;
        rjrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][3]["recovered"].Value;
        rjactive.text = "Active: " + APIresponse["data"]["statewise"][3]["active"].Value;

        mpconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][4]["confirmed"].Value;
        mpdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][4]["deaths"].Value;
        mprecovered.text = "Recovered: " + APIresponse["data"]["statewise"][4]["recovered"].Value;
        mpactive.text = "Active: " + APIresponse["data"]["statewise"][4]["active"].Value;

        tnconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][5]["confirmed"].Value;
        tndeathText.text = "Deaths: " + APIresponse["data"]["statewise"][5]["deaths"].Value;
        tnrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][5]["recovered"].Value;
        tnactive.text = "Active: " + APIresponse["data"]["statewise"][5]["active"].Value;

        upconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][6]["confirmed"].Value;
        updeathText.text = "Deaths: " + APIresponse["data"]["statewise"][6]["deaths"].Value;
        uprecovered.text = "Recovered: " + APIresponse["data"]["statewise"][6]["recovered"].Value;
        upactive.text = "Active: " + APIresponse["data"]["statewise"][6]["active"].Value;

        apconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][7]["confirmed"].Value;
        apdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][7]["deaths"].Value;
        aprecovered.text = "Recovered: " + APIresponse["data"]["statewise"][7]["recovered"].Value;
        apactive.text = "Active: " + APIresponse["data"]["statewise"][7]["active"].Value;

        tgconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][8]["confirmed"].Value;
        tgdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][8]["deaths"].Value;
        tgrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][8]["recovered"].Value;
        tgactive.text = "Active: " + APIresponse["data"]["statewise"][8]["active"].Value;

        wbconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][9]["confirmed"].Value;
        wbdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][9]["deaths"].Value;
        wbrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][9]["recovered"].Value;
        wbactive.text = "Active: " + APIresponse["data"]["statewise"][9]["active"].Value;

        jkconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][10]["confirmed"].Value;
        jkdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][10]["deaths"].Value;
        jkrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][10]["recovered"].Value;
        jkactive.text = "Active: " + APIresponse["data"]["statewise"][10]["active"].Value;

        kaconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][11]["confirmed"].Value;
        kadeathText.text = "Deaths: " + APIresponse["data"]["statewise"][11]["deaths"].Value;
        karecovered.text = "Recovered: " + APIresponse["data"]["statewise"][11]["recovered"].Value;
        kaactive.text = "Active: " + APIresponse["data"]["statewise"][11]["active"].Value;

        klconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][12]["confirmed"].Value;
        kldeathText.text = "Deaths: " + APIresponse["data"]["statewise"][12]["deaths"].Value;
        klrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][12]["recovered"].Value;
        klactive.text = "Active: " + APIresponse["data"]["statewise"][12]["active"].Value;

        pbconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][13]["confirmed"].Value;
        pbdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][13]["deaths"].Value;
        pbrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][13]["recovered"].Value;
        pbactive.text = "Active: " + APIresponse["data"]["statewise"][13]["active"].Value;

        hrconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][14]["confirmed"].Value;
        hrdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][14]["deaths"].Value;
        hrrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][14]["recovered"].Value;
        hractive.text = "Active: " + APIresponse["data"]["statewise"][14]["active"].Value;

        brconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][15]["confirmed"].Value;
        brdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][15]["deaths"].Value;
        brrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][15]["recovered"].Value;
        bractive.text = "Active: " + APIresponse["data"]["statewise"][15]["active"].Value;

        odconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][16]["confirmed"].Value;
        oddeathText.text = "Deaths: " + APIresponse["data"]["statewise"][16]["deaths"].Value;
        odrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][16]["recovered"].Value;
        odactive.text = "Active: " + APIresponse["data"]["statewise"][16]["active"].Value;

        jhconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][17]["confirmed"].Value;
        jhdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][17]["deaths"].Value;
        jhrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][17]["recovered"].Value;
        jhactive.text = "Active: " + APIresponse["data"]["statewise"][17]["active"].Value;

        utconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][18]["confirmed"].Value;
        utdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][18]["deaths"].Value;
        utrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][18]["recovered"].Value;
        utactive.text = "Active: " + APIresponse["data"]["statewise"][18]["active"].Value;

        hpconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][19]["confirmed"].Value;
        hpdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][19]["deaths"].Value;
        hprecovered.text = "Recovered: " + APIresponse["data"]["statewise"][19]["recovered"].Value;
        hpactive.text = "Active: " + APIresponse["data"]["statewise"][19]["active"].Value;



        asconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][21]["confirmed"].Value;
        asdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][21]["deaths"].Value;
        asrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][21]["recovered"].Value;
        asactive.text = "Active: " + APIresponse["data"]["statewise"][21]["active"].Value;

        chconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][22]["confirmed"].Value;
        chdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][22]["deaths"].Value;
        chrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][22]["recovered"].Value;
        chactive.text = "Active: " + APIresponse["data"]["statewise"][22]["active"].Value;

        laconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][24]["confirmed"].Value;
        ladeathText.text = "Deaths: " + APIresponse["data"]["statewise"][24]["deaths"].Value;
        larecovered.text = "Recovered: " + APIresponse["data"]["statewise"][24]["recovered"].Value;
        laactive.text = "Active: " + APIresponse["data"]["statewise"][24]["active"].Value;

        mlconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][25]["confirmed"].Value;
        mldeathText.text = "Deaths: " + APIresponse["data"]["statewise"][25]["deaths"].Value;
        mlrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][25]["recovered"].Value;
        mlactive.text = "Active: " + APIresponse["data"]["statewise"][25]["active"].Value;

        pyconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][26]["confirmed"].Value;
        pydeathText.text = "Deaths: " + APIresponse["data"]["statewise"][26]["deaths"].Value;
        pyrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][26]["recovered"].Value;
        pyactive.text = "Active: " + APIresponse["data"]["statewise"][26]["active"].Value;

        gaconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][27]["confirmed"].Value;
        gadeathText.text = "Deaths: " + APIresponse["data"]["statewise"][27]["deaths"].Value;
        garecovered.text = "Recovered: " + APIresponse["data"]["statewise"][27]["recovered"].Value;
        gaactive.text = "Active: " + APIresponse["data"]["statewise"][27]["active"].Value;

        mnconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][28]["confirmed"].Value;
        mndeathText.text = "Deaths: " + APIresponse["data"]["statewise"][28]["deaths"].Value;
        mnrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][28]["recovered"].Value;
        mnactive.text = "Active: " + APIresponse["data"]["statewise"][28]["active"].Value;

        trconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][29]["confirmed"].Value;
        trdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][29]["deaths"].Value;
        trrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][29]["recovered"].Value;
        tractive.text = "Active: " + APIresponse["data"]["statewise"][29]["active"].Value;

        mzconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][30]["confirmed"].Value;
        mzdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][30]["deaths"].Value;
        mzrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][30]["recovered"].Value;
        mzactive.text = "Active: " + APIresponse["data"]["statewise"][30]["active"].Value;

        arconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][31]["confirmed"].Value;
        ardeathText.text = "Deaths: " + APIresponse["data"]["statewise"][31]["deaths"].Value;
        arrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][31]["recovered"].Value;
        aractive.text = "Active: " + APIresponse["data"]["statewise"][31]["active"].Value;

        nlconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][32]["confirmed"].Value;
        nldeathText.text = "Deaths: " + APIresponse["data"]["statewise"][32]["deaths"].Value;
        nlrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][32]["recovered"].Value;
        nlactive.text = "Active: " + APIresponse["data"]["statewise"][32]["active"].Value;

        skconfirmedText.text = "Confirmed: " + APIresponse["data"]["statewise"][36]["confirmed"].Value;
        skdeathText.text = "Deaths: " + APIresponse["data"]["statewise"][36]["deaths"].Value;
        skrecovered.text = "Recovered: " + APIresponse["data"]["statewise"][36]["recovered"].Value;
        skactive.text = "Active: " + APIresponse["data"]["statewise"][36]["active"].Value;



        // Prints a string containing "string value"

    }
}

