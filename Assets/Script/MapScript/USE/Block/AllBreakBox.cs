using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBreakBox : MonoBehaviour
{

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


