using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRotate : MonoBehaviour
{
    public float num;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        num += 0.01f*Time.deltaTime;
        
        if (num > 360)
            num = 0;
        
        transform.Rotate(num, 0, 0);


    }
}
