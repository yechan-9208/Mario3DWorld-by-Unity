using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCoin : MonoBehaviour
{
    float speed = 5f;
    Vector3 sum;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        sum = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 3, 0);

        if (transform.position.y - sum.y< 2)
        {
            dir = Vector3.up * speed * Time.deltaTime;
            transform.position += dir;
        }else
        {
            Destroy(gameObject, 0.3f);
        }


    

    }
}
