using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGoalFlag : MonoBehaviour
{
    public GameObject FlagPosion;
    Vector3 goalPosion;

    // Start is called before the first frame update
    void Start()
    {
        goalPosion = FlagPosion.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            if (goalPosion.y > transform.position.y)
            {
                transform.position += Vector3.up * 0.05f;
            }
        }
    }
}
