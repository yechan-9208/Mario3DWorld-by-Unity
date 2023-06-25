using System;
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

    public enum stateConst
    {
        IDLE,
        WALLJUMP,
        CRUSHDOWN,
        START
    }

    public stateConst state;



    public float Gravity
    {
        get { return gravity; }
        set { gravity = value; }
    }


    //bool crushbox; ���� �΋Hħ üũ

    #region ���� ����
    public float speed = 5f;
    public float jumpSpeed = 5f;
    public bool gate = false;
    public bool isJunmp;
    public string gravityCondition;
    public bool isWall;
    public bool isDropDown;
    public bool cameraShake;
    public ParticleSystem footParticle1;
    public ParticleSystem footParticle2;
    //public ParticleSystem crushdownParticle;
    public GameObject crushparticle;
    public GameObject crushInstance;
    //private bool playcruch=false;

    Vector3 dir;


    public Animator anim;
    // 0: �⺻����, 1: ������, 2: ����

    CharacterController cc;

    public float gravity = -1f;
    public float yVelocity = 0;
    public float jumpPower = 2;
    #endregion


    #region ���۰� ������Ʈ
    void Start()
    {
        
        jumpPower = 2.4f;
        if(gameObject.name.Contains("Big"))
        { state = stateConst.START; }
        
        gravityCondition = "defaultGravity";
        cc = GetComponent<CharacterController>();

        yVelocity = gravity;

        anim.SetBool("isWall", false);
        isWall = false;
        speed = 0;

        footParticle1.Stop();
        footParticle2.Stop();
    }



    //���� ���¿����� ������Ʈ ���ٲٱ� 1. �⺻�̵� 2. ������ 3.�����������
    void Update()
    {
        switch (state)
        {
            case stateConst.IDLE:
                UpdateIdle();
                break;

            case stateConst.WALLJUMP:
                UpdateWallJump();
                break;

            case stateConst.CRUSHDOWN:
                UpdateCrushdown();
                break;

            case stateConst.START:
                UpdateStart();
                break;


        }
        // �Է� ó��

    }

    public void changeEnd()
    {
        state = stateConst.START;
    }

    private void UpdateStart()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = stateConst.IDLE;
        }
    }

    private void ApplyPush()
    {
        Vector3 pushDirection = transform.forward * 4;
        cc.Move(pushDirection * Time.deltaTime);
    }

    private void UpdateIdle()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        // �޸��� �ִϸ��̼� ����
        if ((h == 0 && v == 0))
        {
        
            anim.SetBool("isRun", false);
            speed = 0f;
            if (speed == 0)
            {
                
                footParticleOff();
            }

            StartCoroutine(AccelCoroutine());

                if (anim.GetBool("isAccel") == true)
                {
                    ApplyPush();
                }
     

        }
        else
        {

            if (!anim.GetBool("isRun"))
            {
                anim.SetBool("isRun", true);
            }


            if (speed > 5f)
            {
                anim.SetBool("isAccel", true);
            }
            else
            {
                anim.SetBool("isAccel", false);
            }

            if (speed < 0.5f)
            {
                speed += 2 * Time.deltaTime;
            }
            else if (speed < 5f)
            {
                speed += 8 * Time.deltaTime;
            }



            Vector3 face = Vector3.right * h + Vector3.forward * v;
            face.Normalize();
            transform.forward = face;

        }
            

        anim.SetFloat("runBlend", speed);
        dir = Vector3.right * h + Vector3.forward * v;
        if (speed > 0.5f)
        {
            
            footParticleON();

        }

        dir.Normalize();

        if (cc.isGrounded)
        {
           yVelocity = 0;
        }

        // ���� ó��
        if (false == isJunmp)
        {

            if (Input.GetButtonDown("Jump"))
            {
                footParticleOff();
                gravityCondition = "jumpGravity"; ; //�����߷�
                yVelocity = jumpPower;
                anim.SetTrigger("Jump");
                anim.SetBool("isJump", true);
                StartCoroutine(jumpCoroutine());
            }
        }

        if (Input.GetButtonDown("Jump") && isWall && isJunmp)
        {

            state = stateConst.WALLJUMP;
            return;

        }

        if (Input.GetKeyDown(KeyCode.R) && isJunmp)
        {
            state = stateConst.CRUSHDOWN;
            return;
        }


    

        Gravitycheck(gravityCondition);
        yVelocity += gravity * Time.deltaTime;
        //dir += Vector3.up * yVelocity;

        cc.Move((dir * speed * Time.deltaTime) + (jumpSpeed * Vector3.up * yVelocity * Time.deltaTime));

    }

    public void footParticleON()
    {
        if (footParticle1.isPlaying && footParticle2.isPlaying) return;
        footParticle1.Play();
        footParticle2.Play();

    }

    public void footParticleOff()
    {
        if (!footParticle1.isPlaying && !footParticle2.isPlaying) return;
        footParticle1.Stop();
        footParticle2.Stop();

    }

    public void PressEnemy()
    {
        gravity = 0;
        yVelocity += 3;
    }



    private IEnumerator AccelCoroutine()
    {

        yield return new WaitForSeconds(0.3f);
        anim.SetBool("isAccel", false);
     
    }


    private IEnumerator jumpCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        isJunmp = true;
        gravityCondition = "jumpGravity";
    }


    float currentTime = 0f;
    float MoveTime;
    private void UpdateWallJump()
    {
        if(dir.magnitude==0)
        {
            state = stateConst.IDLE;
            return; 
        }


        anim.SetTrigger("WallJump");
        MoveTime = 0.4f;
        speed = 3f;
        Vector3 newdir = -dir * 2;
        Vector3 updir = Vector3.up * jumpPower;
        cc.Move((newdir + updir) * Time.deltaTime * speed);

        if (newdir == null) return;
        else
        {
            transform.forward = newdir;
        }

        currentTime += Time.deltaTime;

        if (currentTime >= MoveTime)
        {
            currentTime = 0;
            state = stateConst.IDLE;
        }
    }


    bool hipdrop;
    private void UpdateCrushdown()
    {
        isDropDown = true;
        anim.SetBool("isHIpup", false);
        if (isJunmp)
        {
            if (!hipdrop)
            {
                anim.SetTrigger("HipDrop");
                hipdrop = true;
            }


            currentTime += Time.deltaTime;
            if (currentTime >= 0.7f)
            {
                speed = 20f;
                Vector3 newdir = -Vector3.up;
                cc.Move(newdir * speed * Time.deltaTime);
            }
        }
        else
        {
            cameraShake = true;
            isDropDown = false;
            crushdownparticleON();           
            anim.SetBool("isHIpup",true);            
            StartCoroutine(crushdownCoroutine());

            hipdrop = false;
            currentTime = 0;
            speed = 0;
            state = stateConst.IDLE;
            yVelocity = 0;
           
        }
        #endregion
    }
    private void crushdownparticleON()
    {
        crushInstance = Instantiate(crushparticle, transform.position, transform.rotation);//vfx����
        crushInstance.SetActive(true); //��Ÿ����
    }
    

    
    private IEnumerator crushdownCoroutine()
    {
        yield return new WaitForSeconds(1f); //�ı��ð� ����.
        crushInstance.SetActive(false); //���߱�
        Destroy(crushInstance); //�ı�(������ȿ��)
    }
    


    void Gravitycheck(string gravityCondition)
    {
        switch (gravityCondition)
        {
            case "defaultGravity": //�⺻�߷�
            case "jumpGravity": //���� �߷�
                {
                    Gravity = -5f;
                    break;
                }
            case "crushBlockGravity": // �� �΋H������ �߷�
                {
                    Gravity = -35;
                    break;
                }
        }
    }






}
