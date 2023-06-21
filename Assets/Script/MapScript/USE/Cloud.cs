using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    Collider cloud;
    // Start is called before the first frame update
    void Start()
    {
        cloud = GetComponent<BoxCollider>();
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
        cloud.enabled = true;
    }
}
