using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBox1: MonoBehaviour
{
    bool trig = true;
    public float countjump = 3f;
    public GameObject box1;
    public GameObject box2;
    public GameObject Coin;
    bool check_pow=true;

    // Start is called before the first frame update
    void Start()
    {
        box1.SetActive(true);
        box2.SetActive(false);
        if (Coin != null)
        {
            Coin.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (box1.activeSelf)
        {
            if (other.gameObject.name.Contains("Pow"))
            {
                check_pow = false;
                countjump = 0;
                if (Coin != null)
                {
                    Coin.SetActive(true);
                }
                Movebox(0.1f);
            }
            else if(other.gameObject.name.Contains("Mario"))
            {   
                if (check_pow)
                {
                    if (this.gameObject.name.Contains("Pow"))
                    {
                        countjump = 0;
                        if (box1.activeSelf)
                            Movebox(0.1f);
                    }
                    else
                    {
                        if (Coin != null)
                        {
                            Coin.SetActive(true);
                        }
                        countjump -= 1;
                        Movebox(0.1f);
                    }
                }
            }
            
        }
    }

    void TurnSetDown()
    {
    
        if (countjump == 0)
        {
            box1.SetActive(false);
            box2.SetActive(true);
        }
        iTween.MoveBy(gameObject, iTween.Hash(
    "y", -0.5,
     "easeType", iTween.EaseType.easeOutExpo,
     "delay", 0.1f,
     "speed", 4));
      
    }


    void Movebox(float delayTime)
    {
        if (countjump < 0) return;

        iTween.MoveBy(gameObject, iTween.Hash(
                "y", 0.5,
                "easeType", iTween.EaseType.easeOutExpo,
                "delay", delayTime,
                "speed", 10,
                "oncompletetarget", gameObject,
                "oncomplete", nameof(TurnSetDown)));


    }
}


