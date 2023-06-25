using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootColliderEnemyPress : MonoBehaviour
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



        if(other.gameObject.CompareTag("Enemy"))
        {
            Player.PressEnemy();
        }

    }


}
