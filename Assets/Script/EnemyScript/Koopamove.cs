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
    int RUN = 2;
    int ATTACK = 3;
    int PRESS = 4;
    int NOTFOUND = 5;
    
    int state;

    public GameObject Mario;
    public float speed = 3;
    public int kstack = 0;
    Vector3 direction;
    public GameObject Shell;
    Vector3 offset = new Vector3(0, 0, 1);

    //public GameObject shell;
    public Animator koopamotion;

    void Start()
    {
        state = IDLE;
        
    }

    
    void Update()
    {
        //    direction = Mario.transform.position - this.transform.position;


        //    //transform.position += direction * speed * Time.deltaTime;
        //    //Vector3 direction = Mario.transform.position - transform.position;
        //    float size = direction.magnitude;

        //    if ( size >= 1f && size <= 10f)
        //    {
        //        transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        //        this.koopamotion.SetTrigger("find");
        //        this.koopamotion.SetTrigger("run");
        //        direction.Normalize();
        //        transform.position += direction * kspeed * Time.deltaTime;
        //    }
        //    else if(size > 10f)
        //    {
        //        this.koopamotion.SetTrigger("not found");
        //    }
        //    else
        //    {
        //        //StartCoroutine(Attack);
        //        this.koopamotion.SetTrigger("attack");
        //    }
        //    //IEnumerator Attack()
        //    //{
        //    //    yield return new WaitForSeconds();

        //    //}
        //}
        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.name.Contains("Mario"))
        //    {

        //        kstack -= 1;
        //        if (kstack == -2)
        //        {
        //            this.koopamotion.SetTrigger("press2");
        //            Destroy(this.gameObject);
        //        }

        //        this.koopamotion.SetTrigger("press1");

        //        direction = shell.transform.position - this.transform.position;
        //        transform.rotation = Quaternion.LookRotation(shell.transform.position - this.transform.position);
        //        transform.position += direction * kspeed * Time.deltaTime;

        //    }

        //}
        //direction = Mario.transform.position - this.transform.position;
        //float size = direction.magnitude;
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
        else if (state ==PRESS)
        {
            UpdatePress();
        }
        else if (state == NOTFOUND)
        {
            UpdateNotfound();
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
        //    this.koopamotion.SetTrigger("attack");
        //}

    }
    private void UpdateIdle()
    {
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
            direction.Normalize();
        if (size > 5 && size < 7f)
        {
            //transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
            this.koopamotion.SetTrigger("find");
            transform.LookAt(Mario.transform.position, Vector3.up);

            state = FIND;
        }
        //else if (size < 7f)
        //{
        //    state = NOTFOUND;
        //}


    }
    private void UpdateFind()
    {
        this.koopamotion.SetTrigger("run");
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
        //transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        if (size < 1f)
        {
            state = ATTACK;
        }
        else if ( size >= 7f)
        {
            state = NOTFOUND;
        }

    }
    
    private void UpdateAttack()
    {
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        //transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        transform.position += direction * speed * Time.deltaTime;

        transform.LookAt(Mario.transform.position, Vector3.up);
        direction.Normalize();
        this.koopamotion.SetTrigger("attack");

    }
    private void UpdatePress()
    {
        kstack += 1;
        if(kstack == 1)
        {
            this.koopamotion.SetTrigger("press1");
            Instantiate(Shell, transform.position + offset, Quaternion.identity);

            FollowShell();
            //transform.position += direction * speed * Time.deltaTime;
        }
        if(kstack == 2)
        {
            this.koopamotion.SetTrigger("press2");
            Destroy(this.gameObject);
        }
        
        
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

        if (other.gameObject.name.Contains("Shell"))
        {
            this.koopamotion.SetTrigger("shell");
            Destroy(Shell);

        }
        
    }
    private void FollowShell()
    {
        direction = Shell.transform.position - this.transform.position;
        float size = direction.magnitude;
        direction.Normalize();
        transform.LookAt(Shell.transform.position, Vector3.up);

        transform.position += direction * speed * Time.deltaTime;
    }
}

