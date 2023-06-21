using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCoin : MonoBehaviour
{
    BlueSwitch coinswitch;

    void Start()
    {
        coinswitch = GameObject.Find("Switch").GetComponent<BlueSwitch>();
    }

    void Update()
    {
        transform.Rotate(0, 3, 0);
  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Mario"))
        {
            coinswitch.BLUECOIN++;
            Destroy(gameObject);
        }
    }
}
