using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MBouce : MonoBehaviour
{
    public GameObject player;
    public Animator anim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Mario"))
        {
            MPlayer player_trig = player.GetComponent<MPlayer>();
            player_trig.map_trig = 1;
            anim.SetTrigger("Jump");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Mario"))
        {
            anim.SetTrigger("Wait");
        }
    }
}
