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


    public int stackf=0;
    public GameObject realFlower;
    public GameObject Mario;
    public GameObject Head;
    public GameObject Leaf;
    public float speed = 1;
    Vector3 direction;
    Vector3 offset = new Vector3(0, 0, 1);
    public Animator flowermotion;
    public bool mariomove = false;
    public ParticleSystem FindParticle;
    public ParticleSystem AttackParticle;
    public ParticleSystem DestroyParticle;

    // Start is called before the first frame update
    void Start()
    {
        state = IDLE;
        Mario = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        direction = Mario.transform.position - this.transform.position;
        Mario = GameObject.FindGameObjectWithTag("Player");


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
        direction.y = 0;
        if (size >= 5f && size < 10f)
        {
            transform.LookAt(new Vector3(Mario.transform.position.x, transform.position.y, Mario.transform.position.z), Vector3.up);
            direction.Normalize();
            this.flowermotion.SetTrigger("find");
            this.flowermotion.SetTrigger("find2");
            state = FIND;
            //transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);

        }
    }

    private void UpdateFind()
    {
        //    Find 애니메이션, 플레이어 방향으로 회전

        // 만약 플레이어가 5M 안쪽에 있다면
        //    Attack으로 전이
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        direction.y = 0;
         transform.LookAt(new Vector3(Mario.transform.position.x, transform.position.y, Mario.transform.position.z), Vector3.up);

        if (size < 5f)
        {
            state = ATTACK;

        }
    }

    private void UpdateAttack()
    {
        //    애니메이션, 플레이어 방향으로 회전, 실제 공격행위
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        direction.y = 0;

        
         transform.LookAt(new Vector3(Mario.transform.position.x, transform.position.y, Mario.transform.position.z), Vector3.up);
        if (size < 1f)
        {
            this.flowermotion.SetTrigger("attack");

        }
        else if (size >=1f)
        {
            this.flowermotion.SetTrigger("wait");
        }


    }
    
    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.name.Contains("BodyCollider"))
        //{
        //    //마리오 목숨 스택 까이는 것.
        //}
        if (other.gameObject.name.Contains("FootCollider"))
        {
            this.flowermotion.SetTrigger("press");
            Destroy(realFlower,0.1f);
            Instantiate(Head, transform.position + offset, Quaternion.identity);
    

        }
    }
    public void chasePaticleON()
    {
        if (!AttackParticle.isPlaying)
        {
            AttackParticle.Play();

        }
    }
    public void chasePaticleOff()
    {
        if (AttackParticle.isPlaying)
        {
            AttackParticle.Stop();

        }
    }
    public void findPaticleON()
    {
        if (FindParticle.isPlaying) return;
        FindParticle.Play();
    }
    public void findPaticleOff()
    {
        if (FindParticle.isPlaying) return;
        FindParticle.Stop();

    }
    public void destroyPaticleON()
    {
        if (DestroyParticle.isPlaying) return;
        DestroyParticle.Play();


    }
    public void destroyPaticleOff()
    {
        if (DestroyParticle.isPlaying) return;
        DestroyParticle.Stop();

    }
}
