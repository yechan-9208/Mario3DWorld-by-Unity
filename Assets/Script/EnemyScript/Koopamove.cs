using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//엉금엉금이 할 수 있는 일.

// 1. Idle
// 2. 만약 플레이어가 5M 안쪽에 있다면
//    Attack 애니메이션, 플레이어 방향으로 회전, 실제 공격행위
// 3. 그렇지 않고 만약 플레이어가 10M 안쪽에 있다면
//    Find 애니메이션, 플레이어 방향으로 회전

// 1. Idle : 만약 10M안쪽인가? 그렇다면 Find상태로 전이
// 2. Find : 만약 5M안쪽인가? 그렇다면 Attack상태로 전이
// 3. Attack : 만약 5M보다 큰가? 10M안쪽이면 Find 그렇지 않으면 Idle
// 4. press : 만약 스택이 1번이면 셀을 내보내고 쫓는 목표를 변경. 
// 5. press : 만약 스택이 2번이면 destroy
// 유의  : 도는데 시간이 걸림. 굼바보다 엉금엉금 인식범위가 넓고, 둘다 높이가 낮음 = 즉 거리측정으로 범위를 보는게 아님. 아마 콜라이더 써가지고 접하는 범위가 설정되어있는 것같음..


public class Koopamove : MonoBehaviour
{
    int IDLE = 0;
    int FIND = 1;

    int ATTACK = 3;
    int PRESS = 4;
    int NOTFOUND = 5;
    int state;

    private bool isMoving = false;

    public GameObject Mario;
    public float speed = 3;
    public int kstack = 0;
    Vector3 direction;
    Vector3 sdirection;
    public GameObject Shell;
    public GameObject Naked;
    Vector3 offset = new Vector3(0, 0, 2);
    Vector3 offset2 = new Vector3(1, 1, -2);

    public Animator koopamotion;
    private Transform currentTarget;
    public ParticleSystem FindParticle;
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

        if (state == IDLE)
        {
            //if(kstack==0)
            //{
            currentTarget = Mario.transform;
            //}



            UpdateIdle();
        }
        else if (state == FIND)
        {
            UpdateFind();
            findPaticleON();
        }
        else if (state == ATTACK)
        {
            UpdateAttack();
        }
        else if (state == PRESS)
        {
            UpdatePress();
        }
        else if (state == NOTFOUND)
        {
            UpdateNotfound();
        }
        //else if (state == CHASE)
        //{
        //    FollowShell();
        //    print("l");
        //}


    }
    private void UpdateIdle()
    {
        direction = currentTarget.position - this.transform.position;
        float size = direction.magnitude;
        direction.Normalize();
        if (size > 5 && size < 7f)
        {

            //transform.LookAt(Mario.transform.position, Vector3.up);
            transform.LookAt(new Vector3(Mario.transform.position.x, transform.position.y, Mario.transform.position.z), Vector3.up);
            transform.LookAt(new Vector3(Mario.transform.position.x, transform.position.y, Mario.transform.position.z), Vector3.up);

            this.koopamotion.SetTrigger("find");

            state = FIND;
        }

    }
    private void UpdateFind()
    {

        this.koopamotion.SetTrigger("run");
        direction = currentTarget.position - this.transform.position;
        float size = direction.magnitude;
        transform.LookAt(new Vector3(Mario.transform.position.x, transform.position.y, Mario.transform.position.z), Vector3.up);
        direction.y = 0;
        //direction.x = 0;

        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;

        chasePaticleON();


        if (size < 1f)
        {

            state = ATTACK;
        }
        else if (size >= 7f)
        {
            chasePaticleOff();
            state = NOTFOUND;
        }

    }

    private void UpdateAttack()
    {
        direction = currentTarget.position - this.transform.position;
        float size = direction.magnitude;
        transform.position += direction * speed * Time.deltaTime;

        direction.y = 0;
        transform.LookAt(new Vector3(Mario.transform.position.x, transform.position.y, Mario.transform.position.z), Vector3.up);


        direction.Normalize();
        chasePaticleOff();

        this.koopamotion.SetTrigger("attack");

    }

    bool istrig;
    private void UpdatePress()
    {
        //kstack += 1;


        //if(kstack == 1)
        //{
        if (istrig) return;

        istrig = true;


        this.koopamotion.SetTrigger("press1");

        Instantiate(Shell, transform.position + offset, Quaternion.identity);
        Instantiate(Naked, transform.position + offset2, Quaternion.identity);
        transform.position += new Vector3(0, 0, -4);



        destroyPaticleON();
        //destroypaticleoff();

        Destroy(this.gameObject);

        //currentTarget = Shell.transform;
        //state = CHASE;

        //}
        //if(kstack == 2)
        //{
        //    this.koopamotion.SetTrigger("press2");
        //    Destroy(this.gameObject);
        //}


    }
    private void UpdateNotfound()
    {
        this.koopamotion.SetTrigger("not found");
        state = IDLE;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("BodyCollider"))
        {
            //마리오 목숨스택 -1
        }
        if (other.gameObject.name.Contains("FootCollider"))
        {
            state = PRESS;
        }

        //if (other.gameObject.name.Contains("Shell"))
        //{
        //    this.koopamotion.SetTrigger("shell");
        //    Destroy(Shell);


        //}

    }
    public void chasePaticleON()
    {
        if (!ChaseParticle.isPlaying)
        {
            ChaseParticle.Play();

        }
    }
    public void chasePaticleOff()
    {
        if (ChaseParticle.isPlaying)
        {
            ChaseParticle.Stop();

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
    //private void FollowShell()
    //{
    //    currentTarget = Shell.transform;

    //    sdirection = currentTarget.position - this.transform.position;
    //    sdirection.Normalize();
    //    transform.LookAt(currentTarget);
    //    transform.position += sdirection * speed * Time.deltaTime;
    //    this.koopamotion.SetTrigger("shellchase");
    //    print("k");



    //}
}

