using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{

    PlayerMario Player;
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = PlayerMario.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.name.Contains("Mario")) && !(other.gameObject.name.Contains("Pow")) && !(other.gameObject.name.Contains("Cloud")))
        {
            if (Player.isJunmp)
            {
                if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Box"))
                {
     
                    anim.SetBool("isJump", false);
                    Player.isJunmp = false;
                }
            }
        }


  

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("RealCloud"))
        {
     
            anim.SetBool("isJump", false);
            Player.isJunmp = false;
        }
    }


}
