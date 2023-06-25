using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NakedMove : MonoBehaviour
{
    int IDLE = 0;
    int CHACE = 1;
   

    int state;

    public int stack;
    public GameObject Shell;
    public GameObject Basic;
    public GameObject Mario;
    public float speed = 2;
    Vector3 direction;
    Vector3 offset = new Vector3(0, 0, 0);

    public Animator nakedmotion;

    public ParticleSystem ChaseParticle;


    void Start()
    {
        Mario = GameObject.FindGameObjectWithTag("Player");
        state = IDLE;
    }

    void Update()
    {
        Mario = GameObject.FindGameObjectWithTag("Player");

        direction = Shell.transform.position - this.transform.position;
        direction.y = 0;

        
        if (state == IDLE)
        {
            UpdateIdle();
        }
        else if (state == CHACE)
        {
            UpdateChace();
        }
       

    }
    private void UpdateIdle()
    {

        direction = Shell.transform.position - this.transform.position;
        transform.LookAt(Shell.transform.position, Vector3.up);
        direction.Normalize();
        direction.y = 0;

        transform.LookAt(Shell.transform.position, Vector3.up);
        this.nakedmotion.SetTrigger("find");
        state = CHACE;

        



    }
    private void UpdateChace()
    {
        Shell = GameObject.FindGameObjectWithTag("shell");
        this.nakedmotion.SetTrigger("chace");
        direction = Shell.transform.position - this.transform.position;
        direction.Normalize();
        transform.LookAt(Shell.transform.position, Vector3.up);
        direction.y = 0;
        
        chasePaticleON();
        transform.position += direction * speed * Time.deltaTime; 
  
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Shell"))
        {
            this.nakedmotion.SetTrigger("recover");
            Destroy(Shell.gameObject);
            Instantiate(Basic, transform.position + offset, Quaternion.identity);
            
            Destroy(this.gameObject);
            
        }
        if(other.gameObject.name.Contains("Mario"))
        {
            Destroy(this.gameObject);
        }
        
        
    }
    public void chasePaticleON()
    {
        if (!ChaseParticle.isPlaying)
        {
            ChaseParticle.Play();

        }
    }
} 