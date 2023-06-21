using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 1f;
    public float changeTime = 5f;
    bool vec;
    float currentTime = 0;
    public bool select_Vertical;
    public bool select_Horizontal;
    // Start is called before the first frame update
    Vector3 dir;
    void Start()
    {
        if (select_Vertical)
        {
            dir = Vector3.right;
        }
        if (select_Horizontal)
        {
            dir = Vector3.up;
        }

    }


    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime> changeTime)
        {
            vec=!vec;
            currentTime = 0;
        }

        if (vec ==false)
        {
            transform.position += dir * speed * Time.deltaTime;
        }else
        {
            transform.position += -dir * speed * Time.deltaTime;
        }

        

    }

}
