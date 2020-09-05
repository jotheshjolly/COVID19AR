using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public RectTransform menus;

    public RectTransform contactinfo;
    public RectTransform countriesinfo;



    public GameObject gb;
    public GameObject gb1;

    public Material mat1;
    public Material mat;

    public Material statmat;
    public Material statmat1;

    public Material infomat;
    public Material infomat1;

    public Material gamemat;
    public Material gamemat1;

    public Image homeimg;
    public Image StatImg;
    public Image infoImg;
    public Image GameImg;

    //double value = 4315709;

    // Start is called before the first frame update
    const string ENDPOINT = "https://coronavirus-19-api.herokuapp.com/countries";
    void Start()
    {
        StartCoroutine(GetData());
        //Debug.Log(value.ToString(value.ToString("#,##0,,M", CultureInfo.InvariantCulture)));

        
    }

    IEnumerator GetData()
    {
        UnityWebRequest request = UnityWebRequest.Get(ENDPOINT);

        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log("Error");
        }
        else
        {
            ParseData(request.downloadHandler.text);
        }
    }

    /* 
     * {"country":"India","cases":1440371,"todayCases":4352,"deaths":32866,"todayDeaths":54,"recovered":921303,"active":486202,"critical":8944,
     * "casesPerOneMillion":1043,"deathsPerOneMillion":24,"totalTests":16806803,"testsPerOneMillion":12171},
    */
    void ParseData(string text)
    {
        
        //Debug.Log(text);

        

       
      

    }
    // Update is called once per frame
    public void StatClick()
    {
        gb.SetActive(false);
        gb1.SetActive(true);
        homeimg.material = mat1;
        StatImg.material = statmat1;
        infoImg.material = infomat1;
        GameImg.material = gamemat;

        menus.anchoredPosition = new Vector2(-848f, 848f);
        contactinfo.anchoredPosition = new Vector2(-848f, 848f);
    }

    public void HomeClick()
    {
        gb.SetActive(true);
        gb1.SetActive(false);
        homeimg.material = mat;
        StatImg.material = statmat;
        infoImg.material = infomat1;
        GameImg.material = gamemat;

        menus.anchoredPosition = new Vector2(-848f, 848f);
        contactinfo.anchoredPosition = new Vector2(-848f, 848f);
        countriesinfo.anchoredPosition = new Vector2(-848f, 848f);
    }

    public void InfoClick()
    {
        // gb.SetActive(true);
        // gb1.SetActive(false);
        homeimg.material = mat1;
        StatImg.material = statmat;
        infoImg.material = infomat;
        GameImg.material = gamemat;
    }

    public void GameClick()
    {
        // gb.SetActive(true);
        // gb1.SetActive(false);
        homeimg.material = mat1;
        StatImg.material = statmat;
        infoImg.material = infomat1;
        GameImg.material = gamemat1;
    }

    public void MenuBtn()
    {
        menus.anchoredPosition = Vector2.zero;
    }

    public void ContactBtn()
    {
        contactinfo.anchoredPosition = Vector2.zero;
        menus.anchoredPosition = new Vector2(-848f, 848f);
        countriesinfo.anchoredPosition = new Vector2(-848f, 848f); 
    }

    public void BackBtn()
    {
        menus.anchoredPosition = new Vector2(-848f,848f);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
    public void CountriesBtn()
    {
        countriesinfo.anchoredPosition = Vector2.zero;
        menus.anchoredPosition = new Vector2(-848f, 848f);
        contactinfo.anchoredPosition = new Vector2(-848f, 848f);
    }


}
