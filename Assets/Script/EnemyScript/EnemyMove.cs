using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표를 향해 이동하고 싶다.

public class EnemyMove : MonoBehaviour
{
    int IDLE = 0;
    int FIND = 1;
    int ATTACK = 2;

    int state;

    public int stack;
    public GameObject Mario;
    public float speed = 3;
    Vector3 direction;

    public Animator goombamotion;
    public float currentAngle;


    void Start()
    {
        state = IDLE;
    }

    void Update()
    {
        //transform.position += direction * speed * Time.deltaTime;
        //Vector3 direction = Mario.transform.position - transform.position;
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        if (state == IDLE)
        {
            UpdateIdle();
        }
        else if (state == FIND)
        {
            UpdateFind();
        }
        else if (state == ATTACK)
        {
            UpdateAttack();
        }

        //if (size < 10f)
        //{
        //    this.goombamotion.SetTrigger("find");
        //    transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        //    direction.Normalize();
        //    this.goombamotion.SetTrigger("run");
        //    transform.position += direction * speed * Time.deltaTime;
        //}
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

    }
    private void UpdateIdle()
    {
        float size = direction.magnitude;
        direction = Mario.transform.position - this.transform.position;
        direction.Normalize();
        if (size > 5 && size < 7f)
        {
            transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
            this.goombamotion.SetTrigger("find");
            state = FIND;
        }


    }
    private void UpdateFind()
    {
        this.goombamotion.SetTrigger("run");
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        if (size < 5f)
        {
            state = ATTACK;
        }
    }
    private void UpdateAttack()
    {
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        direction.Normalize();
        this.goombamotion.SetTrigger("attack");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Mario"))
        {
            Destroy(this.gameObject);
            
        }
        
    }
}
