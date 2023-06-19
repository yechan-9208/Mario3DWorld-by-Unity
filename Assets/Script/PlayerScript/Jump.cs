using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{


    public float jumpForce = 5f;
    public int maxJumps = 2;

    private int jumpCount = 0;
    private bool isJumping = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // �����̽��ٸ� ������ ���� �õ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < maxJumps && !isJumping)
            {
                isJumping = true;
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
                jumpCount++;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �ٴڿ� ������ ���� ������ Ƚ�� �ʱ�ȭ
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            isJumping = false;
        }
    }
}
