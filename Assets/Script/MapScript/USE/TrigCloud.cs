using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigCloud : MonoBehaviour
{
    public GameObject realCloud;
    Collider cloud;

    // Start is called before the first frame update
    void Start()
    {
        cloud = realCloud.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Mario"))
        {
            cloud.enabled = false;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Mario"))
        {
     
               cloud.enabled = true;
        }
    }
}
