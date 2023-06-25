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
    //public ParticleSystem FindParticle;
    public ParticleSystem ChaseParticle;
    public ParticleSystem DestroyParticle;


    void Start()
    {
        state = IDLE;
        Mario = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {        
        Mario = GameObject.FindGameObjectWithTag("Player");

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
        transform.position += direction * speed * Time.deltaTime;
        chasePaticleON();
        print("l");
        this.goombamotion.SetTrigger("run");
        if (size < 1)
        {
            
            state = ATTACK;
        }
        
    }
    private void UpdateAttack()
    {
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        direction.Normalize();
        transform.LookAt(Mario.transform.position, Vector3.up);
        transform.position += direction * speed * Time.deltaTime;
        chasePaticleOff();
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
            //Invoke("", delay);
        //}
        
    }
    public void chasePaticleON()
    {
        if (ChaseParticle.isPlaying) return;
        
            ChaseParticle.Play();

        
    }
    public void chasePaticleOff()
    {
        if (ChaseParticle.isPlaying) return;
        
            ChaseParticle.Stop();

        
    }
    //public void findPaticleON()
    //{
    //    if (FindParticle.isPlaying) return;
    //    FindParticle.Play();
    //}
    //public void findPaticleOff()
    //{
    //    if (FindParticle.isPlaying) return;
    //    FindParticle.Stop();

    //}
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

        