using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 꽃이 할 수 있는 일
// 1. Idle
// 2. 만약 플레이어가 5M 안쪽에 있다면
//    Attack 애니메이션, 플레이어 방향으로 회전, 실제 공격행위
// 3. 그렇지 않고 만약 플레이어가 10M 안쪽에 있다면
//    Find 애니메이션, 플레이어 방향으로 회전

// 1. Idle : 만약 10M안쪽인가? 그렇다면 Find상태로 전이
// 2. Find : 만약 5M안쪽인가? 그렇다면 Attack상태로 전이
// 3. Attack : 만약 5M보다 큰가? 10M안쪽이면 Find 그렇지 않으면 Idle



public class FlowerMove : MonoBehaviour
{

    int IDLE = 0;
    int FIND = 1;
    int ATTACK = 2;

    int state;


    public int stackf;

    public GameObject Mario;
    public float speed = 1;
    Vector3 direction;

    public Animator flowermotion;
    public bool mariomove = false;



    // Start is called before the first frame update
    void Start()
    {
        state = IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Mario.transform.position - this.transform.position;

        float size = direction.magnitude;
        //transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
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

        //direction = Mario.transform.position - this.transform.position;
        //float size = direction.magnitude;
        //if (size >= 5f && size < 10f)
        //{
        //    transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        //    this.flowermotion.SetTrigger("find");
        //    this.flowermotion.SetTrigger("wait");
        //    //direction.Normalize();

        //}
        //else if (size < 5f)
        //{
        //    mariomove = true;
        //}
        //if (mariomove == true)
        //{
        //    this.flowermotion.SetTrigger("attack");
        //}
    }

    private void UpdateIdle()
    {
        // 만약 플레이어가 10M 안쪽에 있다면
        // Find로 전이
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        if (size >= 5f && size < 10f)
        {
            this.flowermotion.SetTrigger("find");
            state = FIND;
        }
        direction.Normalize();

        transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);




    }

    private void UpdateFind()
    {
        //    Find 애니메이션, 플레이어 방향으로 회전

        // 만약 플레이어가 5M 안쪽에 있다면
        //    Attack으로 전이
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        if(size < 5f)
        {
            state = ATTACK;

        }
    }

    private void UpdateAttack()
    {
        //    애니메이션, 플레이어 방향으로 회전, 실제 공격행위
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        this.flowermotion.SetTrigger("attack");


    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Mario"))
            Destroy(this.gameObject);
    }
}
