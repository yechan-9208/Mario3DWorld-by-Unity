using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    int IDLE = 0;
    
    public GameObject Mario;
    public float speed = 5;
    public bool move = false;
    Vector3 direction;
    public Animator birdmotion;

    public ParticleSystem FlyParticle;

    // Start is called before the first frame update
    void Start()
    {
        
        Mario = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        if (move == false)
        {
            direction = Mario.transform.position - this.transform.position;

            float size = direction.magnitude;

            if (size < 5f)
            {

                direction.Normalize();
                this.birdmotion.SetTrigger("run");
                move = true;

            }

        }
        else if (move == true)
        {
            flyPaticleON();
            transform.position -= Vector3.down * speed * Time.deltaTime;
        }
    }
    public void flyPaticleON()
    {
        if (!FlyParticle.isPlaying)
        {
            FlyParticle.Play();

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        move = true;
    }
}

