using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
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
        if (!other.gameObject.name.Contains("Mario"))
        {
            //print("head : " + other);
        }
        if (other.gameObject.name.Contains("Box"))
        {
            Player.gravityCondition = "crushBlockGravity";
            //print("head box: " + other);
        }
    }
}
