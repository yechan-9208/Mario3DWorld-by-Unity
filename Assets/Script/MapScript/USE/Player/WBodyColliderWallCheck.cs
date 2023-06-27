using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBodyColliderWallCheck : MonoBehaviour
{
    PlayerMario Player;
    public Animator anim;
    Collider body;

    // Start is called before the first frame update
    void Start()
    {
        Player = PlayerMario.instance;
        body = GetComponent<BoxCollider>();
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
    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.name.Contains("Mario") && !other.gameObject.name.Contains("Pow") && !other.gameObject.name.Contains("Coin")&& !(other.gameObject.name.Contains("Cloud"))&&!(other.CompareTag("Enemy")))
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
