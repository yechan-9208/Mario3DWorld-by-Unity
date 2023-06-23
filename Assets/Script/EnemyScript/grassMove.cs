using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassMove : MonoBehaviour
{

    public GameObject Mario;
    public float speed = 3;
    public bool move = false;
    Vector3 direction;
    float maxScale = 3;
    float minScale = 0.5f;

    //public Animator grassmotion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //for()
        //transform.localScale += new Vector3(0, 1, 0);

        //        if (move == false)
        //        {
        //            direction = Mario.transform.position - this.transform.position;


        //            //transform.position += direction * speed * Time.deltaTime;
        //            //Vector3 direction = Mario.transform.position - transform.position;
        //            float size = direction.magnitude;

        //            for ()
        //            {
        //                transform.localScale += new Vector3(0, 2, 0);
        //                transform.localScale
        //            }
        //            //if (size < 3f)
        //            //{

        //            //    direction.Normalize();
        //            //    //this.grassmotion.SetTrigger("move");
        //            //    move = true;

        //            //}

        //        }
        //        else if (move == true)
        //        {
        //            transform.localScale += new Vector3(0,2,0);
        //        }

        //    }
        //    private void OnCollisionEnter(Collision other)
        //    {
        //        if (other.gameObject.name.Contains("Mario"))
        //        {
        //            move = true;

        //        }
    }
}


//if (Triggered && transform.localScale.x < MaxScale.x)
//{
//    transform.localScale = Vector3.Slerp(transform.localScale, MaxScale, growSpeed * Time.deltaTime);
//}

//if (deTrigger && transform.localScale.x > MiniScale.x)
//{
//    transform.localScale = Vector3.Slerp(transform.localScale, MiniScale, Speed * Time.deltaTime);

