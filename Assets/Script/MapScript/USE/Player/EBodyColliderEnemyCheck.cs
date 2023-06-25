using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBodyColliderEnemyCheck : MonoBehaviour
{
    MPlayer Player;

    Collider body;

    // Start is called before the first frame update
    void Start()
    {
        Player = MPlayer.instance;
        body = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isInvincible)
        {
            body.enabled = false;
        }else
        {
            body.enabled = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        print(other);
        if (other.CompareTag("Enemy"))
        {
            
            if (Player.gameObject.name.Contains("Big"))
            {
                GameManager.instance.BigToSmallMario();
            }
            else
            {
                GameManager.instance.gameOver();
            }

        }
    }


}
