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
            //������ ������� -1
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

