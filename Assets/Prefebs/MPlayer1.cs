using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayer1 : MonoBehaviour
{
    //bool crushbox; 블럭과 부딫침 체크

    #region 변수 선언
    public float speed = 5f;
    public bool gate = false;
    bool isJunmp;
    Vector3 dir;
    

    public Animator animator;
    // 0: 기본상태, 1: 점프대, 2: 가속

    CharacterController cc;

    float gravity=10f;
    float yVelocity = 0;
    float jumpPower = 2f;
    #endregion

    #region 시작과 업데이트
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //gravity = crushbox == false ? -5 : -15;
        //gravity = -5;

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
        if (Input.GetButtonDown("Jump"))
        {
            if (false == isJunmp)
            {
                gravity = -5f;
                yVelocity = jumpPower;
                animator.SetTrigger("Jump");
                isJunmp = true;
            }
            else
            {
                
            }
        }

        // 중력 및 이동 계산
        yVelocity += gravity * Time.deltaTime;
        dir += Vector3.up * yVelocity;
        cc.Move(dir * speed * Time.deltaTime);

    }
    #endregion



    #region 충돌 감지 (블럭 부딫혔을때 빠르게 아래로 내려오게)
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // 박스와의 충돌 처리
    //    if (collision.gameObject.tag.Contains("Box"))
    //    {
    //        crushbox = true;
    //    }
    //    // 땅과의 충돌 처리
    //    if (collision.gameObject.tag.Contains("Ground"))
    //    {
    //        crushbox = false;
    //    }
    //}
    #endregion 
}


