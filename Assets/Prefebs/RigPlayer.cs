using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigPlayer : MonoBehaviour
{
    public float speed = 5f;
    public bool gate = false;
    bool isJump = false;
    Vector3 dir;

    public Animator animator;
    // 0: default state, 1: ramp, 2: acceleration

    Rigidbody rb;

    public float gravity = -30f;
    public float yVelocity = 0;
    public float jumpPower = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //if ((h + v) == 0)
        //{
        //    animator.SetBool("isRun", false);
        //}
        //else
        //{
        //    animator.SetBool("isRun", true);
        //    Vector3 face = Vector3.right * h + Vector3.forward * v;
        //    face.Normalize();
        //    transform.forward = face;
        //}

        if (Input.GetButtonDown("Jump") && !isJump)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
        }

        dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();

        yVelocity += gravity * Time.deltaTime;
        dir += Vector3.up * yVelocity;

        rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
    }



    private void OnTriggerEnter(Collider other)
    {
        isJump = false;
    }
}
