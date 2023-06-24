using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 굼바가 할 수 있는 일.
// 1. Idle + 좁은 범위안을 걸어다닐 수 있다.
// 2. 만약 플레이어가 5M 안쪽에 있다면
//    Attack 애니메이션, 플레이어 방향으로 회전, 실제 공격행위
// 3. 그렇지 않고 만약 플레이어가 10M 안쪽에 있다면
//    Find 애니메이션, 플레이어 방향으로 회전

// 1. Idle : 만약 10M안쪽인가? 그렇다면 Find상태로 전이
// 2. Find : 만약 5M안쪽인가? 그렇다면 Attack상태로 전이
// 3. Attack : 만약 5M보다 큰가? 10M안쪽이면 Find 그렇지 않으면 Idle



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
        direction.y = 0;

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


    }
    private void UpdateIdle()
    {
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        direction.y = 0;

        if (size > 5 && size < 7)
        {
            transform.LookAt(Mario.transform.position, Vector3.up);

            direction.Normalize();

            //transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
            this.goombamotion.SetTrigger("find");
            state = FIND;
        }



    }
    private void UpdateFind()
    {
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        direction.y = 0;
        transform.LookAt(Mario.transform.position, Vector3.up);

        //transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);

        transform.position += direction * speed * Time.deltaTime; 
        this.goombamotion.SetTrigger("run");
        if (size < 1)
        {
            state = ATTACK;
        }
        //if
    }
    private void UpdateAttack()
    {
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        direction.Normalize();
        transform.LookAt(Mario.transform.position, Vector3.up);
        transform.position += direction * speed * Time.deltaTime;

        //transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        this.goombamotion.SetTrigger("attack");


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("FootCollider"))
        {
            this.goombamotion.SetTrigger("press");
            Destroy(this.gameObject);
            
        }
        
        //if(other.gameObject.name.Contains("BodyCollider"))
        //{
            //마리오 스택 -1 
            //잠깐 멈추기.
        //}
        
    }
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
        //if (size < 1f)
        //{
        //    this.goombamotion.SetTrigger("attack");
        //}