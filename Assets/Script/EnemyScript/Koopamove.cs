using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;
//목표를 향해 이동하고 싶다.
//public class SetActive();

//엉금엉금은 이동하고싶다.
//엉금엉금은 
public class Koopamove : MonoBehaviour
{
    int IDLE = 0;
    int FIND = 1;
    int ATTACK = 2;
    int PRESS = 3;

    int state;

    public GameObject Mario;
    public float speed = 3;
    public int kstack = 0;
    Vector3 direction;

    public GameObject shell;
    public Animator koopamotion;

    void Start()
    {
        state = IDLE;
        
    }

    
    void Update()
    {
        //    direction = Mario.transform.position - this.transform.position;


        //    //transform.position += direction * speed * Time.deltaTime;
        //    //Vector3 direction = Mario.transform.position - transform.position;
        //    float size = direction.magnitude;

        //    if ( size >= 1f && size <= 10f)
        //    {
        //        transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        //        this.koopamotion.SetTrigger("find");
        //        this.koopamotion.SetTrigger("run");
        //        direction.Normalize();
        //        transform.position += direction * kspeed * Time.deltaTime;
        //    }
        //    else if(size > 10f)
        //    {
        //        this.koopamotion.SetTrigger("not found");
        //    }
        //    else
        //    {
        //        //StartCoroutine(Attack);
        //        this.koopamotion.SetTrigger("attack");
        //    }
        //    //IEnumerator Attack()
        //    //{
        //    //    yield return new WaitForSeconds();

        //    //}
        //}
        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.name.Contains("Mario"))
        //    {

        //        kstack -= 1;
        //        if (kstack == -2)
        //        {
        //            this.koopamotion.SetTrigger("press2");
        //            Destroy(this.gameObject);
        //        }

        //        this.koopamotion.SetTrigger("press1");
        //        Instantiate(shell, new Vector3(0, 0, 0), Quaternion.identity);

        //        direction = shell.transform.position - this.transform.position;
        //        transform.rotation = Quaternion.LookRotation(shell.transform.position - this.transform.position);
        //        transform.position += direction * kspeed * Time.deltaTime;

        //        if(other.gameObject.name.Contains("Shell"))
        //        {
        //            this.koopamotion.SetTrigger("shell");
        //            Destroy(shell);

        //        }
        //    }

        //}
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
     if (state == IDLE)
        {
            UpdateIdle();
        }
        else if (state == FIND)
        {
            UpdateFind();
        }
        else if (state == ATTACK)
        {
            UpdateAttack();
        }
        else if (state ==PRESS)
        {
            UpdatePress();
        }

        //if (size < 10f)
        //{
        //    this.goombamotion.SetTrigger("find");
        //    transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        //    direction.Normalize();
        //    this.goombamotion.SetTrigger("run");
        //    transform.position += direction * speed * Time.deltaTime;
        //}
        //else
        //{
        //    this.goombamotion.SetTrigger("walk");
        //    //transform.rotation
        //    //transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
        //    transform.position += transform.forward * speed * Time.deltaTime;
        //    //transform.right += 90;
        //}

        //else if
        //{
        //    this.goombamotion.SetTrigger("not found");
        //}
        //if (size < 1f)
        //{
        //    this.koopamotion.SetTrigger("attack");
        //}

    }
    private void UpdateIdle()
    {
        float size = direction.magnitude;
        direction = Mario.transform.position - this.transform.position;
        if (size > 5 && size < 7f)
        {
            transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
            this.koopamotion.SetTrigger("find");
            direction.Normalize();
            state = FIND;
        }


    }
    private void UpdateFind()
    {
        this.koopamotion.SetTrigger("run");
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
        if (size < 5f)
        {
            state = ATTACK;
        }
    }
    private void UpdateAttack()
    {
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        //transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);

        transform.LookAt(Mario.transform.position, Vector3.up);
        direction.Normalize();
        this.koopamotion.SetTrigger("attack");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Mario"))
        {
            state = PRESS;
            Destroy(this.gameObject);
        }
        
    }
    private void UpdatePress()
    {
        
    }
}

