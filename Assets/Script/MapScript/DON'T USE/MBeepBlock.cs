using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBeepBlock : MonoBehaviour
{
    float curTime = 0f;
    float switchTime = 2f;
    GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(1).gameObject;

        //print(child.name);
        if(gameObject.name.Contains("Blue"))
        {

            child.SetActive(false);
        }

        if(gameObject.name.Contains("Red"))
        { 
            child.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= switchTime)
        {
            if (child.activeSelf)
            {
                child.SetActive(false);
            }
            else
            {
                child.SetActive(true);
            }
            curTime = 0;
        }
    }
}
