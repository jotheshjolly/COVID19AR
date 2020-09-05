using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    private string url = "https://api.rootnet.in/covid19-in/notifications";
    void Start()
    {
        WWW request = new WWW(url);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;

    }
    void Update()
    {
        
    }


    [System.Serializable]
    public class RootObject
    {
        public List<UserObject> notifications;
    }
}
