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

    public enum stateConst
    {
        IDLE,
        WALLJUMP,
        CRUSHDOWN
    }

    public stateConst state;



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
            if (speed < 7f)
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

             if (Input.GetButtonDown("Jump"))
            {
                //print("jump");
                gravityCondition = "jumpGravity"; ; //�����߷�
                yVelocity = jumpPower;
                animator.SetTrigger("Jump");
                StartCoroutine(jumpCoroutine());
            }
        }

        if (Input.GetButtonDown("Jump") && isWall&&isJunmp)
        {

            state = stateConst.WALLJUMP;
            return;

        }

        if(Input.GetKeyDown(KeyCode.R)&&isJunmp)
        {
            state = stateConst.CRUSHDOWN;
            return;
        }



        Gravitycheck(gravityCondition);
        yVelocity += gravity * Time.deltaTime;
        //dir += Vector3.up * yVelocity;

        cc.Move((dir * speed * Time.deltaTime) + (jumpSpeed * Vector3.up * yVelocity * Time.deltaTime));

    }


    private IEnumerator jumpCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        isJunmp = true;
    }

    float wallJumpPower = 2f;

    float currentTime = 0f;
    float MoveTime;
    private void UpdateWallJump()
    {
        MoveTime = 0.4f;
        speed = 3f;
        Vector3 newdir = -dir*2;
        Vector3 updir =Vector3.up * jumpPower;
        cc.Move((newdir + updir)*Time.deltaTime*speed);

        transform.forward = newdir;

        currentTime += Time.deltaTime;

        if(currentTime>=MoveTime)
        {
            currentTime = 0;
            state = stateConst.IDLE;
        }
    }

    private void UpdateCrushdown()
    {
        MoveTime = 0.2f;
        currentTime += Time.deltaTime;

        if (currentTime >= MoveTime)
        {
            speed = 20f;
            Vector3 newdir = Vector3.down ;
            cc.Move(newdir * speed * Time.deltaTime);
        }

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
                    Gravity = -5f;
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
