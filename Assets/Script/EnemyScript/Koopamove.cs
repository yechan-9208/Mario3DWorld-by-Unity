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
    
    public GameObject Mario;
    public float kspeed = 3;
    public int kstack = 0;
    Vector3 direction;
    public GameObject shell;
    public Animator koopamotion;

    void Start()
    {

        
    }

    
    void Update()
    {
        direction = Mario.transform.position - this.transform.position;


        //transform.position += direction * speed * Time.deltaTime;
        //Vector3 direction = Mario.transform.position - transform.position;
        float size = direction.magnitude;

        if ( size >= 1f && size <= 10f)
        {
            transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
            this.koopamotion.SetTrigger("find");
            this.koopamotion.SetTrigger("run");
            direction.Normalize();
            transform.position += direction * kspeed * Time.deltaTime;
        }
        else if(size > 10f)
        {
            this.koopamotion.SetTrigger("not found");
        }
        else
        {
            //StartCoroutine(Attack);
            this.koopamotion.SetTrigger("attack");
        }
        //IEnumerator Attack()
        //{
        //    yield return new WaitForSeconds();

        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Mario"))
        {
            
            kstack -= 1;
            if (kstack == -2)
            {
                this.koopamotion.SetTrigger("press2");
                Destroy(this.gameObject);
            }

            this.koopamotion.SetTrigger("press1");
            Instantiate(shell, new Vector3(0, 0, 0), Quaternion.identity);

            direction = shell.transform.position - this.transform.position;
            transform.rotation = Quaternion.LookRotation(shell.transform.position - this.transform.position);
            transform.position += direction * kspeed * Time.deltaTime;

            if(collision.gameObject.name.Contains("Shell"))
            {
                this.koopamotion.SetTrigger("shell");
                Destroy(shell);
                
            }
        }
    }
}

