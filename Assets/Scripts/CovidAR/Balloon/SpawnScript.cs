using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnpoints;
    public GameObject[] ballons;
    void Start()
    {
        StartCoroutine(StartSpawing());
    }

    IEnumerator StartSpawing()
    {
        yield return new WaitForSeconds(4);

        for(int i = 0; i < 3; i++)
        {
            Instantiate(ballons[i], spawnpoints[i].position, Quaternion.identity);
        }
        StartCoroutine(StartSpawing());
    }
}
