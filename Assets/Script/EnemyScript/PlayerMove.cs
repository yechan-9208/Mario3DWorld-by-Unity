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

        //�̵�����
        //P= PO + vt
        //transform.position = transform.position + Vector3.right * 5 * Time.deltaTime;
        //������� �Է¿� ���� , �����¿�� ������ �����/ �̵��ϰ�ʹ�.
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
