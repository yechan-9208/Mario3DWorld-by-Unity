using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MPlayer : MonoBehaviour
{

    public static MPlayer instance;

    private void Awake()
    {
        instance = this;
    }

    enum stateConst
    {
        IDLE,
        WALLJUMP,
        CRUSHDOWN
    }

    stateConst state;



    public float Gravity
    {
        get { return gravity; }
        set { gravity = value; }
    }


    //bool crushbox; ���� �΋Hħ üũ

    #region ���� ����
    public float speed = 5f;
    public float jumpSpeed = 5f;
    public bool gate = false;
    public bool isJunmp;
    public string gravityCondition;
    public bool isWall;
    Vector3 dir;


    public Animator animator;
    // 0: �⺻����, 1: ������, 2: ����

    CharacterController cc;

    public float gravity = -1f;
    float yVelocity = 0;
    float jumpPower = 2f;
    #endregion

    #region ���۰� ������Ʈ
    void Start()
    {
        state = stateConst.IDLE;
        gravityCondition = "defaultGravity";
        cc = GetComponent<CharacterController>();
    }

 

    //���� ���¿����� ������Ʈ ���ٲٱ� 1. �⺻�̵� 2. ������ 3.�����������
    void Update()
    {
       switch(state)
        {
            case stateConst.IDLE:
                UpdateIdle();
                break;

            case stateConst.WALLJUMP:
                UpdateWallJump();
                break;

            case stateConst.CRUSHDOWN:
                UpdateCrushdown();
                break;
        }
        // �Է� ó��
        
    }

    private void UpdateIdle()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        // �޸��� �ִϸ��̼� ����
        if ((h == 0 && v == 0))
        {
            animator.SetBool("isRun", false);
            speed = 0f;
        }
        else
        {
            if (speed < 5f)
            {
                speed += 5 * Time.deltaTime;
                //print(speed);  
            }
            animator.SetBool("isRun", true);
            Vector3 face = Vector3.right * h + Vector3.forward * v;
            face.Normalize();
            transform.forward = face;
        }

        dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();

        // ���� ó��
        if (false == isJunmp)
        {
            if (Input.GetButtonDown("Jump") && isWall)
            {

                //print("wall"); 
                //return;

            }
            else if (Input.GetButtonDown("Jump"))
            {
                print("jump");
                gravityCondition = "jumpGravity"; ; //�����߷�
                yVelocity = jumpPower;
                animator.SetTrigger("Jump");
                isJunmp = true;

            }
        }


        Gravitycheck(gravityCondition);
        yVelocity += gravity * Time.deltaTime;
        //dir += Vector3.up * yVelocity;

        cc.Move((dir * speed * Time.deltaTime) + (jumpSpeed * Vector3.up * yVelocity * Time.deltaTime));

    }

    private void UpdateWallJump()
    {
        throw new NotImplementedException();
    }

    private void UpdateCrushdown()
    {
        throw new NotImplementedException();
    }
    #endregion









    void Gravitycheck(string gravityCondition)
    {
        switch (gravityCondition)
        {
            case "defaultGravity": //�⺻�߷�
                {
                    Gravity = -0.5f;
                    break;
                }
            case "jumpGravity": //���� �߷�
                {
                    Gravity = -5;
                    break;
                }
            case "crushBlockGravity": // �� �΋H������ �߷�
                {
                    Gravity = -20;
                    break;
                }
        }
    }



}
