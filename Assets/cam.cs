using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float sensitivity = 2f; // 마우스 감도 조절 변수

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); // 마우스 X 축 입력값 가져오기

        // 카메라 좌우 회전
        transform.Rotate(0f, mouseX * sensitivity, 0f);
    }
}
