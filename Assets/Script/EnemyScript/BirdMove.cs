using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    public GameObject Mario;
    public float speed = 5;
    public bool move = false;
    Vector3 direction;
    public Animator birdmotion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (move == false)
        {
            direction = Mario.transform.position - this.transform.position;


            //transform.position += direction * speed * Time.deltaTime;
            //Vector3 direction = Mario.transform.position - transform.position;
            float size = direction.magnitude;

            if (size < 3f)
            {

                direction.Normalize();
                this.birdmotion.SetTrigger("run");
                move = true;

            }

        }
        else if (move == true)
        {
            transform.position -= Vector3.down * speed * Time.deltaTime;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        move = true;
    }
}

