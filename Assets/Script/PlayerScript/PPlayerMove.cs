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

    //ĳ���� ��Ʈ�ѷ�
    CharacterController cc;

    //�߷�
    float gravity = -20f;
    
    //�����Ŀ�
    float jumpPower = 5f;

    public Animator animator;

    private ControllerColliderHit lastHit; // ���� ���� �߰�

    private bool isGounded = true; // ���� �ִ��� ���θ� ��Ÿ���� ����
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
        // ������� �Է��� �޾� �̵� ó��
        float h = Input.GetAxis("Horizontal"); //a : -1,d : 1, ������ �ʾ��� ��� : 0
        float v = Input.GetAxis("Vertical"); // s : -1, w : 1, ������ �ʾ��� ��� : 0

        Vector3 movementDirection = new Vector3(h, 0f, v);
        movementDirection.Normalize();

        // ĳ���� �̵�
        controller.Move(movementDirection * speed * Time.deltaTime);

        // ĳ���� ȸ��
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // ���� ����
        if (cc.isGrounded)
        {
            // ���� Ƚ�� �ʱ�ȭ
            jumpCount = 0;

            if (Input.GetButtonDown("Jump"))
            {
                // yVelocity�� jumpForce�� �����Ͽ� ����
                verticalVelocity = jumpForce;
                // Jump �ִϸ��̼� Ʈ���� ȣ��
                animator.SetTrigger("Jump");

            }
            else
            {
                verticalVelocity = 0f;

                //isGround �ִϸ��̼� Ʈ���� ȣ��
                animator.SetTrigger("isGound");
            }
        }

        else
        {
            // �������� �������� Ȯ��
            if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
            {
                // �������� �õ�
                verticalVelocity = jumpForce;
                jumpCount++;
                //Jump �ִϸ��̼� Ʈ���� ȣ��
                animator.SetTrigger("Jump");
            }

            // �߷� ����
            verticalVelocity += gravity * Time.deltaTime;
        }

        // ���� �̵� ���
        movefactor = movementDirection * speed;
        movefactor.y = verticalVelocity;

        // ĳ���� �̵� ����
        controller.Move(movefactor * Time.deltaTime);

        // �ִϸ��̼� ����
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





