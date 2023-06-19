using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPowBox : MonoBehaviour
{
    SphereCollider Scollider;
    bool trig;
    public int limitRadius = 3;
    public int speed = 10;
    void Start()
    {
        Scollider = gameObject.GetComponent<SphereCollider>();
        Scollider.radius = 1;
        Scollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(trig==true)
        {
            Scollider.enabled = true;
            Scollider.radius += speed*Time.deltaTime;
        }
        if(Scollider.radius> limitRadius)
        {
            trig = false;
            Scollider.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Mario")|| other.gameObject.name.Contains("Pow"))
        {
            trig = true;
        }
    }


}
