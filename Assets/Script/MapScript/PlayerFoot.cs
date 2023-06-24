using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.name.Contains("Mario")) && !(other.gameObject.name.Contains("Pow")) && !(other.gameObject.name.Contains("Cloud")))
        {
            if (Player.isJunmp)
            {
                if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Box"))
                {
                    print("11111111111111111111");
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
                print("22222222222222222");
            anim.SetBool("isJump", false);
            Player.isJunmp = false;
        }
    }


}
