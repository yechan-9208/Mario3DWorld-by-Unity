using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootColliderEnemyPress : MonoBehaviour
{

    PlayerMario Player;

    
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
        if(other.gameObject.CompareTag("Enemy"))
        {
            
            Player.PressEnemy();
        }

    }


}
