using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPlayerMove : MonoBehaviour
{
    public float jumpForce = 5f;
    public int maxJumps = 2;

    private int jumpCount = 0;
    private bool isJumping = false;
    private Rigidbody rb;

    public float speed = 10f;
    public float rotationSpeed =10f;
    public float verticalVelocity= 0f;
    public CharacterController controller;
    public Vector3 movefactor;
    public Vector3 lastmove;

    //캐릭터 컨트롤러
    CharacterController cc;

    //중력
    float gravity = -20f;
    
    //점프파워
    float jumpPower = 5f;

    public Animator animator;

    private ControllerColliderHit lastHit; // 변수 선언 추가

    private bool isGounded = true; // 땅에 있는지 여부를 나타내는 변수
    private bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 사용자의 입력을 받아 이동 처리
        float h = Input.GetAxis("Horizontal"); //a : -1,d : 1, 누르지 않았을 경우 : 0
        float v = Input.GetAxis("Vertical"); // s : -1, w : 1, 누르지 않았을 경우 : 0

        Vector3 movementDirection = new Vector3(h, 0f, v);
        movementDirection.Normalize();

        // 캐릭터 이동
        controller.Move(movementDirection * speed * Time.deltaTime);

        // 캐릭터 회전
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // 점프 로직
        if (cc.isGrounded)
        {
            // 점프 횟수 초기화
            jumpCount = 0;

            if (Input.GetButtonDown("Jump"))
            {
                // yVelocity를 jumpForce로 설정하여 점프
                verticalVelocity = jumpForce;
                // Jump 애니메이션 트리거 호출
                animator.SetTrigger("Jump");

            }
            else
            {
                verticalVelocity = 0f;

                //isGround 애니메이션 트리거 호출
                animator.SetTrigger("isGound");
            }
        }

        else
        {
            // 이중점프 가능한지 확인
            if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
            {
                // 이중점프 시도
                verticalVelocity = jumpForce;
                jumpCount++;
                //Jump 애니메이션 트리거 호출
                animator.SetTrigger("Jump");
            }

            // 중력 적용
            verticalVelocity += gravity * Time.deltaTime;
        }

        // 수직 이동 계산
        movefactor = movementDirection * speed;
        movefactor.y = verticalVelocity;

        // 캐릭터 이동 적용
        controller.Move(movefactor * Time.deltaTime);

        // 애니메이션 제어
        bool ismoving = movementDirection.magnitude != 0f;

            animator.SetBool("Run", ismoving);
            animator.SetBool("isGround", cc.isGrounded);
        }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}





