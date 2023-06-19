using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayer : MonoBehaviour
{
    public float speed = 5f;
    public int map_trig = 0;
    public bool gate = false;
    private Coroutine checkCorot;
    public Vector3 pipe;
    Vector3 dir;
    bool crushbox;

    Animator animator;
    // 0 : 기본상태 1: 점프대 2: 가속


    CharacterController cc;

    float gravity;
    float yVelocity = 0;
    float jumpPower = 2f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        gravity = crushbox == false ? -5 : -15;


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (gate == true)
        {
            gameObject.SetActive(false);
            transform.position = pipe;
            gameObject.SetActive(true);
            gate = false;
        }
        else
        {
                dir = Vector3.right * h + Vector3.forward * v;
                dir.Normalize();
 
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpPower;
                animator.SetTrigger("Jump");
            }

            yVelocity += gravity * Time.deltaTime;
            dir += Vector3.up * yVelocity;

            //transform.position += vec * speed * Time.deltaTime;
            cc.Move(dir * speed * Time.deltaTime);
        }
    }
    private IEnumerator go()
    {
        yield return new WaitForSeconds(0.5f);
        map_trig = 0;
        checkCorot = null;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Contains("Box"))
        {
            crushbox = true;
        }
        if (collision.gameObject.tag.Contains("Ground"))
        {
            crushbox = false;
        }
    }
}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MPlayer : MonoBehaviour
//{
//    public float speed = 5f;
//    public int map_trig = 0;
//    public bool gate =false;
//    private Coroutine checkCorot;
//    public Vector3 pipe;
//    Vector3 dir;
//    bool crushbox;

//    public Animator animator;
//    // 0 : 기본상태 1: 점프대 2: 가속


//    CharacterController cc;

//    float gravity;
//    float yVelocity = 0;
//    float jumpPower = 2f;

//    // Start is called before the first frame update
//    void Start()
//    {
//        cc = GetComponent<CharacterController>();

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        gravity = crushbox == false ? -5 : -15;


//        float h = Input.GetAxis("Horizontal");
//        float v = Input.GetAxis("Vertical");

//        if (gate == true)
//        {
//            gameObject.SetActive(false);
//            transform.position = pipe;
//            gameObject.SetActive(true);
//            gate = false;
//        }
//        else
//        {
//            if (map_trig == 2)
//            {
//                dir = Vector3.right * 2f * h + Vector3.forward * 2f * v;
//            }
//            else
//            {
//                dir = Vector3.right * h + Vector3.forward * v;
//                dir.Normalize();
//            }


//            if (map_trig == 1)
//            {
//                if (checkCorot == null)
//                {

//                    yVelocity = 3f;
//                    checkCorot = StartCoroutine(go());

//                }

//            }

//            if (Input.GetButtonDown("Jump"))
//            {
//                yVelocity = jumpPower;
//            }

//            yVelocity += gravity * Time.deltaTime;
//            dir += Vector3.up * yVelocity;

//                //transform.position += vec * speed * Time.deltaTime;
//                cc.Move(dir * speed * Time.deltaTime);
//        }
//    }
//    private IEnumerator go()
//    {
//        yield return new WaitForSeconds(0.5f);
//        map_trig = 0;
//        checkCorot = null;
//    }

//    private void OnCollisionEnter(Collision collision)
//    {

//        if(collision.gameObject.tag.Contains("Box"))
//        {
//            crushbox = true;
//        }
//        if (collision.gameObject.tag.Contains("Ground"))
//        {
//            crushbox = false;
//        }
//    }
//}




