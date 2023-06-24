using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    public float smoothSpeed;
    public GameObject player;
    Transform cameraTransform;
    // Start is called before the first frame update

    public float shakeDuration = 0.3f; // ��鸲 ���� �ð�
    public float shakeIntensity = 0.1f; // ��鸲 ����

    private Vector3 originalPosition; // ���� ī�޶� ��ġ
    private float currentShakeDuration; // ���� ��鸲 ���� �ð�


    void Start()
    {
        currentShakeDuration = shakeDuration;
        //originalPosition = transform.localPosition; // �ʱ� ī�޶� ��ġ ����
        cameraTransform = transform;
        smoothSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (MPlayer.instance.state == null) return;

        //if(MPlayer.instance.state == MPlayer.stateConst.CRUSHDOWN)
        //{
        //    Vector3 randomPosition = Random.insideUnitSphere * shakeIntensity;
        //    transform.localPosition = transform.position + randomPosition;

        //    currentShakeDuration -= Time.deltaTime;
        //    if(currentShakeDuration <= 0)
        //    {
        //        transform.localPosition = transform.position;
        //        MPlayer.instance.state = MPlayer.stateConst.IDLE;
        //    }
        //}
        //else
        {
            Vector3 desiredPosition = player.transform.position - cameraTransform.forward * 11f + cameraTransform.up * 2f;

            cameraTransform.position = Vector3.Lerp(cameraTransform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        }

    }
 
}
