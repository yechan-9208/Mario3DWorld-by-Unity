using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMove : MonoBehaviour
{
    
    public GameObject Mario;
    public float speed = 0.3f;
    Vector3 direction;
    public Animator flowermotion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        direction = Mario.transform.position - this.transform.position;
        float size = direction.magnitude;
        if(size < 10f)
        {
            transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);
            this.flowermotion.SetTrigger("find");
            direction.Normalize();
            if(size < 1f)
            {
                this.flowermotion.SetTrigger("attack");
            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        this.flowermotion.SetTrigger("press");
        //GameObject.SetActive(true);
        Destroy(this.gameObject);
        
        

    }
}
