using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float sensitivity = 2f; // ���콺 ���� ���� ����

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); // ���콺 X �� �Է°� ��������

        // ī�޶� �¿� ȸ��
        transform.Rotate(0f, mouseX * sensitivity, 0f);
    }
}
