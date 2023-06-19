using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;
//목표를 향해 이동하고 싶다.
//public class SetActive();
public class EnemyMove : MonoBehaviour
{
    
    public GameObject Mario;
    public float speed = 3;
    Vector3 direction;
    public Animator goombamotion;
    public float currentAngle;

  
    void Start()
    {
    }

        void Update()
        {
            direction = Mario.transform.position - this.transform.position;


            //transform.position += direction * speed * Time.deltaTime;
            //Vector3 direction = Mario.transform.position - transform.position;
            float size = direction.magnitude;

            if (size < 10f)
            {
                this.goombamotion.SetTrigger("find");
                transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
                direction.Normalize();
                this.goombamotion.SetTrigger("run");
                transform.position += direction * speed * Time.deltaTime;
            }
            //else
            //{
            //    this.goombamotion.SetTrigger("walk");
            //    //transform.rotation
            //    //transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
            //    transform.position += transform.forward * speed * Time.deltaTime;
            //    //transform.right += 90;
            //}

        //else if
        //{
        //    this.goombamotion.SetTrigger("not found");
        //}
        if (size < 1f)
            {
                this.goombamotion.SetTrigger("attack");
            }
            
            //transform.LookAt(transform);
            //transform.rotation = Quaternion.LookRotation(this.transform.rotation, Quaternion.LookRotation.Lerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * speed));
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains("Mario"))
            {
                this.goombamotion.SetTrigger("press");
                Destroy(this.gameObject);

            }
        }
    
}

