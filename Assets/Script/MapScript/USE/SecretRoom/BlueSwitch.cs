using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSwitch : MonoBehaviour
{
    GameObject head;
    bool trig = true;
    int bluecoin = 0;
    public int pase = 0;
    public GameObject[] BlueCoinPase;

    public int BLUECOIN
    {
        get { return bluecoin; }
        set
        {
            bluecoin = value;
        }
    }
    void Start()
    {
        head = GameObject.FindGameObjectWithTag("Switch");
    }

    void Update()
    {
        switch (pase)
        {
            case 1:
                {
                    BlueCoinPase[0].SetActive(true);
                    if (BLUECOIN == 9)
                    {
                        pase++;
                    }
                    break;

                }
            case 2:
                {
                    BlueCoinPase[1].SetActive(true);

                    if (BLUECOIN == 22)
                    {
                        pase++;
                    }
                    break;
                }
            case 3:
                {
                    BlueCoinPase[2].SetActive(true); break;
                    if (BLUECOIN == 23)
                    {
                        UIManager.instance.COIN += 100;
                    }
                }
        }




    }

    private void OnTriggerEnter(Collider other)
    {
        if (trig)
        {
            Vector3 dir = head.transform.position;
            dir.y -= 0.2f;
            head.transform.position = dir;
            trig = false;
            pase++;
        }
    }
}
