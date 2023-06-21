using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{

    MPlayer Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = MPlayer.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.name.Contains("Mario")) && !(other.gameObject.name.Contains("Pow"))&&!(other.gameObject.name.Contains("Cloud")))
        {
            if (Player.isJunmp)
            {
                //print(other);
                Player.isJunmp = false;
                Player.gravityCondition = "defaultGravity";
            }
            //print("foot: " + other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name.Contains("RealCloud"))
        {
            Player.isJunmp = false;
        }
    }


}
