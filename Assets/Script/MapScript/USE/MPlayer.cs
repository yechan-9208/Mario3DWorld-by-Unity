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


    public float Gravity
    {
        get { return gravity; }
        set { gravity = value; }
    }


    //bool crushbox; 블럭과 부딫침 체크

    #region 변수 선언
    public float speed = 5f;
    public bool gate = false;
    public bool isJunmp;
    public string gravityCondition;
    public bool isWall;
    Vector3 dir;


    public Animator animator;
    // 0: 기본상태, 1: 점프대, 2: 가속

    CharacterController cc;

    public float gravity = -1f;
    float yVelocity = 0;
    float jumpPower = 2f;
    #endregion

    #region 시작과 업데이트
    void Start()
    {
        gravityCondition = "defaultGravity";
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //gravity = crushbox == false ? -5 : -15;


        // 입력 처리
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 달리기 애니메이션 설정
        if ((h + v) == 0)
        {
            animator.SetBool("isRun", false);
        }
        else
        {
            animator.SetBool("isRun", true);
            Vector3 face = Vector3.right * h + Vector3.forward * v;
            face.Normalize();
            transform.forward = face;
        }

        dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();

        // 점프 처리

        /*  gravityCondition = "defaultGravity";*/ //기본중력
        if (Input.GetButtonDown("Jump"))
        {
            if (false == isJunmp)
            {
                gravityCondition = "jumpGravity"; ; //점프중력
                yVelocity = jumpPower;
                animator.SetTrigger("Jump");
                isJunmp = true;
            }

        
        }




        Gravitycheck(gravityCondition);

        yVelocity += gravity * Time.deltaTime;
        dir += Vector3.up * yVelocity;
        cc.Move(dir * speed * Time.deltaTime);

    }
    #endregion

    void Gravitycheck(string gravityCondition)
    {
        switch (gravityCondition)
        {
            case "defaultGravity": //기본중력
                {
                    Gravity = -1;
                    break;
                }
            case "jumpGravity": //점프 중력
                {
                    Gravity = -5;
                    break;
                }
            case "crushBlockGravity": // 블럭 부딫쳤을때 중력
                {
                    Gravity = -20;
                    break;
                }
        }
    }



}
