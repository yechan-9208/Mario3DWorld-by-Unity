using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayer1 : MonoBehaviour
{
    //bool crushbox; ���� �΋Hħ üũ

    #region ���� ����
    public float speed = 5f;
    public bool gate = false;
    bool isJunmp;
    Vector3 dir;
    

    public Animator animator;
    // 0: �⺻����, 1: ������, 2: ����

    CharacterController cc;

    float gravity=10f;
    float yVelocity = 0;
    float jumpPower = 2f;
    #endregion

    #region ���۰� ������Ʈ
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //gravity = crushbox == false ? -5 : -15;
        //gravity = -5;

        // �Է� ó��
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // �޸��� �ִϸ��̼� ����
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

        // ���� ó��
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

        // �߷� �� �̵� ���
        yVelocity += gravity * Time.deltaTime;
        dir += Vector3.up * yVelocity;
        cc.Move(dir * speed * Time.deltaTime);

    }
    #endregion



    #region �浹 ���� (�� �΋H������ ������ �Ʒ��� ��������)
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // �ڽ����� �浹 ó��
    //    if (collision.gameObject.tag.Contains("Box"))
    //    {
    //        crushbox = true;
    //    }
    //    // ������ �浹 ó��
    //    if (collision.gameObject.tag.Contains("Ground"))
    //    {
    //        crushbox = false;
    //    }
    //}
    #endregion 
}


