using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mgoal : MonoBehaviour
{
    public Animator anim;
    GameObject child;
    AudioSource finish;
    public GameObject gamingSound;
    AudioSource sound;

    float currTime = 0;
    float AftFlagTime = 1.5f;
    float EndTime = 3f;
    bool AftCheck;


    void Start()
    {
        finish = GetComponent<AudioSource>();
        finish.Stop();
        sound = gamingSound.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (AftCheck)
        {
  
            currTime += Time.deltaTime;
            if (currTime >= AftFlagTime)
            {
                child = gameObject.transform.GetChild(1).gameObject;
                child.SetActive(true);
                MPlayer.instance.changeEnd();
            }
            if (currTime >= EndTime)
            {
                DirectorAction.instance.camarea.SetActive(true);
                DirectorAction.instance.isgoal = true;
                DirectorAction.instance.pd.Play();


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!AftCheck)
        {
            anim.SetTrigger("Goal");
            sound.Stop();
            finish.Play();

        }

        child = gameObject.transform.GetChild(0).gameObject;
        child.SetActive(false);
        AftCheck = true;



    }
}
