using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ݾ����� �� �� �ִ� ��.

// 1. Idle
// 2. ���� �÷��̾ 5M ���ʿ� �ִٸ�
//    Attack �ִϸ��̼�, �÷��̾� �������� ȸ��, ���� ��������
// 3. �׷��� �ʰ� ���� �÷��̾ 10M ���ʿ� �ִٸ�
//    Find �ִϸ��̼�, �÷��̾� �������� ȸ��

// 1. Idle : ���� 10M�����ΰ�? �׷��ٸ� Find���·� ����
// 2. Find : ���� 5M�����ΰ�? �׷��ٸ� Attack���·� ����
// 3. Attack : ���� 5M���� ū��? 10M�����̸� Find �׷��� ������ Idle
// 4. press : ���� ������ 1���̸� ���� �������� �Ѵ� ��ǥ�� ����. 
// 5. press : ���� ������ 2���̸� destroy
// ����  : ���µ� �ð��� �ɸ�. ���ٺ��� ���ݾ��� �νĹ����� �а�, �Ѵ� ���̰� ���� = �� �Ÿ��������� ������ ���°� �ƴ�. �Ƹ� �ݶ��̴� �ᰡ���� ���ϴ� ������ �����Ǿ��ִ� �Ͱ���..


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
            //������ ������� -1
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

