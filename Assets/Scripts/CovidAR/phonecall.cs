using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phonecall : MonoBehaviour
{
    public GameObject gb;
    public GameObject gb1;

    public string search;

    public Image searchCountry;
    public Image searchContact;

    public InputField country;
    public InputField contact;

   


    public void Phonecall()
    {
        Application.OpenURL("tel:+04429510500");
    }
    public void SearchButton()
    {
        searchCountry.gameObject.SetActive(true);
        
    }

    public void SearchContact()
    {
        searchContact.gameObject.SetActive(true);
    
    }
    public void BackBtn()
    {
        searchContact.gameObject.SetActive(false);
        searchCountry.gameObject.SetActive(false);
    }
    public void action()
    {
        gb.SetActive(false);
    }

    

}
