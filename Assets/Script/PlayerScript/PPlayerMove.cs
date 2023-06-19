using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPlayerMove : MonoBehaviour
{
    public float speed = 5;

    //ĳ���� ��Ʈ�ѷ�
    CharacterController cc;

    //�߷�
    float gravity = -20;
    //�����ӷ�
    float yvelocity = 0;
    //�����Ŀ�
    float jumpPower = 5;

    //Animator
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //1. ������� �Է��� ���� (w,s,a,d)
        float h = Input.GetAxis("Horizontal"); //a : -1,d : 1, ������ �ʾ��� ��� : 0
        float v = Input.GetAxis("Vertical"); // s : -1, w : 1, ������ �ʾ��� ��� : 0
        //2. ������ �����.
        Vector3 dirH = transform.right * h;
        Vector3 dirV = transform.forward * v;
        Vector3 dir = dirH + dirV;

        //Move �ִϸ��̼��� �����Ѵ�.
        anim.SetTrigger("Move");

        //���࿡ �����̽��ٸ� ������ 
        if (Input.GetButtonDown("Jump"))
        {
            //yVelocity �� jumpPower �Ѵ�.
            yvelocity = jumpPower;
            //Idle �ִϸ��̼��� ��������
            anim.SetTrigger("Idle");
        }
        //yVelocity�� jumpPower�Ѵ�.
        yvelocity += gravity * Time.deltaTime;
        //dir�� y ����  yvelocity �� �����Ѵ�.
        dir.y = yvelocity;
        //yVelocity ���� ���� �ٿ��ش�. (�߷¿� ���ؼ�)

        //3. �� �������� ��� �̵��ϰ� �ʹ�.
        //p=p0+vt
        //transform.position = transform.position + dir * speed * Time.deltaTime;
        cc.Move(dir * speed * Time.deltaTime);
    }
}
