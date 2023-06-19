using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPlayerMove : MonoBehaviour
{
    public float speed = 5;

    //캐릭터 컨트롤러
    CharacterController cc;

    //중력
    float gravity = -20;
    //수직속력
    float yvelocity = 0;
    //점프파워
    float jumpPower = 5;

    //Animator
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //1. 사용자의 입력을 받자 (w,s,a,d)
        float h = Input.GetAxis("Horizontal"); //a : -1,d : 1, 누르지 않았을 경우 : 0
        float v = Input.GetAxis("Vertical"); // s : -1, w : 1, 누르지 않았을 경우 : 0
        //2. 방향을 만든다.
        Vector3 dirH = transform.right * h;
        Vector3 dirV = transform.forward * v;
        Vector3 dir = dirH + dirV;

        //Move 애니메이션을 실행한다.
        anim.SetTrigger("Move");

        //만약에 스페이스바를 누르면 
        if (Input.GetButtonDown("Jump"))
        {
            //yVelocity 를 jumpPower 한다.
            yvelocity = jumpPower;
            //Idle 애니메이션을 실행하자
            anim.SetTrigger("Idle");
        }
        //yVelocity를 jumpPower한다.
        yvelocity += gravity * Time.deltaTime;
        //dir의 y 값에  yvelocity 를 셋팅한다.
        dir.y = yvelocity;
        //yVelocity 값을 점점 줄여준다. (중력에 의해서)

        //3. 그 방향으로 계속 이동하고 싶다.
        //p=p0+vt
        //transform.position = transform.position + dir * speed * Time.deltaTime;
        cc.Move(dir * speed * Time.deltaTime);
    }
}
