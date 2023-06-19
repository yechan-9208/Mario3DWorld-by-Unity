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
        // 스페이스바를 누르면 점프 시도
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
        // 바닥에 닿으면 점프 가능한 횟수 초기화
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            isJumping = false;
        }
    }
}
