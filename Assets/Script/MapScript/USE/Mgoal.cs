using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mgoal : MonoBehaviour
{
    public Animator anim;
    GameObject child;

    float currTime = 0;
    float AftFlagTime = 1.5f;
    bool AftCheck;
    public AudioSource bgm;
    AudioSource Finish;


    void Start()
    {
       Finish = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AftCheck)
        {
            currTime += Time.deltaTime;
            if (currTime >= AftFlagTime)
            {
                child = gameObject.transform.GetChild(1).gameObject;
                child.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
  
        if (!AftCheck)
        {
            bgm.Stop();
            Finish.Play();
            anim.SetTrigger("Goal");
        }
        child = gameObject.transform.GetChild(0).gameObject;
        child.SetActive(false);
        AftCheck = true;
     

   
    }
}
