using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDash : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Mario"))
        {
            MPlayer player_trig = player.GetComponent<MPlayer>();
            player_trig.map_trig = 2;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Mario"))
        {
            MPlayer player_trig = player.GetComponent<MPlayer>();
            player_trig.map_trig = 0;

        }
    }


}
