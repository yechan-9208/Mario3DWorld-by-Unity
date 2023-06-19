using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //currentTime += 10 * Time.deltaTime;

        //int i = 0;
        //i = i + 1;
        //i += 1;
        //i++;
        //++i;

        //이동공식
        //P= PO + vt
        //transform.position = transform.position + Vector3.right * 5 * Time.deltaTime;
        //사용자의 입력에 따라 , 상하좌우로 방향을 만들고/ 이동하고싶다.
        //transform.position += Vector3.right * 5 * Time.deltaTime;
        //transform.Translate(Vector3.up * 5 * Time.deltaTime);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //float z = Input.GetAxis("z")
        Vector3 dir = h * Vector3.right + v * Vector3.up;
        dir.Normalize();
        Vector3 velocity = dir * speed;
        transform.position += dir * speed * Time.deltaTime;


    }
}
