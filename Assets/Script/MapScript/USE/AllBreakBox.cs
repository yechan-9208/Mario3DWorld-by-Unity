using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBreakBox : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Contains("Mario")|| other.gameObject.name.Contains("Pow"))
        {
  
            Movebox(0.1f);

        }
    }

    void TurnSetDown()
    {
        Destroy(this.gameObject);
    }


    void Movebox(float delayTime)
    {
        iTween.MoveBy(gameObject, iTween.Hash(
                "y", 0.5,
                "easeType", iTween.EaseType.easeOutExpo,
                "delay", delayTime,
                "speed", 4,
                "oncompletetarget", gameObject,
                "oncomplete", nameof(TurnSetDown)));
    }
}


