using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �� �� �ִ� ��
// 1. Idle
// 2. ���� �÷��̾ 5M ���ʿ� �ִٸ�
//    Attack �ִϸ��̼�, �÷��̾� �������� ȸ��, ���� ��������
// 3. �׷��� �ʰ� ���� �÷��̾ 10M ���ʿ� �ִٸ�
//    Find �ִϸ��̼�, �÷��̾� �������� ȸ��

// 1. Idle : ���� 10M�����ΰ�? �׷��ٸ� Find���·� ����
// 2. Find : ���� 5M�����ΰ�? �׷��ٸ� Attack���·� ����
// 3. Attack : ���� 5M���� ū��? 10M�����̸� Find �׷��� ������ Idle



public class FlowerMove : MonoBehaviour
{

    int IDLE = 0;
    int FIND = 1;
    int ATTACK = 2;

    int state;


    public int stackf=0;

    public GameObject Mario;
    public GameObject Head;
    public GameObject Leaf;
    public float speed = 1;
    Vector3 direction;
    Vector3 offset = new Vector3(0, 0, 1);

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
        // ���� �÷��̾ 10M ���ʿ� �ִٸ�
        // Find�� ����
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        if (size >= 5f && size < 10f)
        {
            transform.LookAt(Mario.transform.position, Vector3.up);
            direction.Normalize();
            this.flowermotion.SetTrigger("find");
            this.flowermotion.SetTrigger("find2");
            state = FIND;
            //transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);

        }
    }

    private void UpdateFind()
    {
        //    Find �ִϸ��̼�, �÷��̾� �������� ȸ��

        // ���� �÷��̾ 5M ���ʿ� �ִٸ�
        //    Attack���� ����
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        //transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
            transform.LookAt(Mario.transform.position, Vector3.up);

        if (size < 5f)
        {
            state = ATTACK;

        }
    }

    private void UpdateAttack()
    {
        //    �ִϸ��̼�, �÷��̾� �������� ȸ��, ���� ��������
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        //transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        transform.LookAt(Mario.transform.position, Vector3.up);
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
        //    //������ ��� ���� ���̴� ��.
        //}
        if (other.gameObject.name.Contains("FootCollider"))
        {
            this.flowermotion.SetTrigger("press");
            Destroy(this.gameObject);
            Instantiate(Head, transform.position + offset, Quaternion.identity);
            Instantiate(Leaf, transform.position + offset, Quaternion.identity);
            //print("Head");
            //print("Leaf");
            //Destroy(Head);
            //Destroy(Leaf);

        }
    }
}
