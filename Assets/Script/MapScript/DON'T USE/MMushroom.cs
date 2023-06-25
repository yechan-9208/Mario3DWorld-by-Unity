using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMushroom : MonoBehaviour
{
    public float speed = 2f;
    int rand;

    // Start is called before the first frame update
    void Start()
    {
        rand =Random.Range(0, 360);
        transform.Rotate(0, rand, 0);

    }

    // Update is called once per frame
   
    void Update()
    {
        
        Vector3 dir = transform.forward;
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.forward = transform.forward * -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Mario"))
        {
            GameManager.instance.GrowUp();
            Destroy(gameObject);
        }
    }

}
