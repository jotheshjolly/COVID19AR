using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchScript : MonoBehaviour
{
    public string theName;
    public GameObject inputField;

    void Update()
    {
        theName = inputField.GetComponent<Text>().text;

        for (int i = 0; i < GetCountries.countryObjects.Count; i++)
        {
            GameObject countryObj = GetCountries.countryObjects[i];
            Text countryText = countryObj.transform.Find("CountryName").GetComponent<Text>();
            if (countryText.text.ToLower().Contains(theName.ToLower())) countryObj.SetActive(true);
            else countryObj.SetActive(false);
        }
    }
}
