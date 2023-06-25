using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ٰ� �� �� �ִ� ��.
// 1. Idle + ���� �������� �ɾ�ٴ� �� �ִ�.
// 2. ���� �÷��̾ 5M ���ʿ� �ִٸ�
//    Attack �ִϸ��̼�, �÷��̾� �������� ȸ��, ���� ��������
// 3. �׷��� �ʰ� ���� �÷��̾ 10M ���ʿ� �ִٸ�
//    Find �ִϸ��̼�, �÷��̾� �������� ȸ��

// 1. Idle : ���� 10M�����ΰ�? �׷��ٸ� Find���·� ����
// 2. Find : ���� 5M�����ΰ�? �׷��ٸ� Attack���·� ����
// 3. Attack : ���� 5M���� ū��? 10M�����̸� Find �׷��� ������ Idle



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
            //������ ���� -1 
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

        