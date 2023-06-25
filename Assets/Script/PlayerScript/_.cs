using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class _ : MonoBehaviour
{
    public GameObject vfx;
    // Start is called before the first frame update
    void Start()
    {
        vfx.SetActive(false);

    }

    float currentTime = 0f;
    public float TargetTime = 6f;
    // Update is called once per frame
    void Update()
    {
        print(currentTime);
        currentTime += Time.deltaTime;
        if(currentTime>TargetTime)
        {
            vfx.SetActive(true);
        }
    }
}
