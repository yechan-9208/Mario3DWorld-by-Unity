using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioSwitch : MonoBehaviour
{

    public GameObject bigMario;
    public GameObject smallMario;
    bool marioSwitch; //false = big , true = small
    GameObject currentMario;

    void Start()
    {
        bigMario.SetActive(true);
        smallMario.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(marioSwitch)
        {
            currentMario = bigMario;
        }else
        {
             currentMario = smallMario;
        }

        transform.position = currentMario.transform.position;

    }


    private void OnTriggerEnter(Collider other)
    {
        
    }
}
