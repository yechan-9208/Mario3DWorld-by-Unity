using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class vcam : MonoBehaviour
{
    CinemachineVirtualCamera Vcam;
    
    

    // Start is called before the first frame update
    void Start()
    {
        Vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vcam.Follow = GameManager.instance.currentMario.transform;
        Vcam.LookAt = GameManager.instance.currentMario.transform;

    




        if (gameObject.name.Contains("2"))
        {
            transform.position = GameManager.instance.currentMario.transform.position +new Vector3(0,2,-5);
        }


    }
}
