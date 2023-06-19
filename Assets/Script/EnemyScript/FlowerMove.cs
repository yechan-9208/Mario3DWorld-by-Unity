using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMove : MonoBehaviour
{
    public int stackf;
    public GameObject Mario;
    public float speed = 1;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = Mario.transform.position - this.transform.position;
        direction.Normalize();

        transform.rotation = Quaternion.LookRotation(Mario.transform.position - this.transform.position);



    }
    private void OnCollisionEnter(Collision collision)
    {
        //GameObject.SetActive(true);
        Destroy(this.gameObject);
        stackf -= 1;

    }
}
