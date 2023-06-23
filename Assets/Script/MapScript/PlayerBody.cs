using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    MPlayer Player;
    public Animator anim;

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
        if (!other.gameObject.name.Contains("Mario") && !other.gameObject.name.Contains("Pow") && !other.gameObject.name.Contains("Coin")&& !(other.gameObject.name.Contains("Cloud")))
        {
            Player.isWall = true;
            anim.SetBool("isWall", true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.name.Contains("Mario"))
        {
            Player.isWall = false;
            anim.SetBool("isWall", false);
        }
    }
}
