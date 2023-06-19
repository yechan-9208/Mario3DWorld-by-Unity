using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDount : MonoBehaviour
{
    bool trig;
    float currTime = 0;
   


    void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        if(trig)
        {
            currTime += Time.deltaTime;
            if (currTime > 0.6f)
            {
                transform.position += Vector3.down * 0.025f;
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {

        Renderer rend = transform.GetChild(1).GetComponent<Renderer>();
        rend.material.color = new Color(1f, 0.513f, 0.513f);
        trig = true;
    }
}
