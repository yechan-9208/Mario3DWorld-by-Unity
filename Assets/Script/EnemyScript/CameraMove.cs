using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;
//��ǥ�� ���� �̵��ϰ� �ʹ�.
//public class SetActive();
public class CameraMove : MonoBehaviour
{
    public int stack;
    public GameObject Mario;
    public float speed;
    Vector3 direction;



    void Start()
    {
        //MPlayer Mario = new MPlayer();
        //this.speed = Mario.speed;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMario Mario = new PlayerMario();
        this.speed = Mario.speed;



        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();

        transform.position += dir * this.speed * Time.deltaTime;

    }
}
