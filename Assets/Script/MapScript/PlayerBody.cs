using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
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
    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.name.Contains("Mario") && !other.gameObject.name.Contains("Pow") && !other.gameObject.name.Contains("Coin"))
        {
            Player.isWall = true;
            print(other);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.name.Contains("Mario"))
        {
            Player.isWall = false;

        }
    }
}
