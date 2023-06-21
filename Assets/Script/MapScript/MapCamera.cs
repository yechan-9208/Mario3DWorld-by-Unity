using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    public float smoothSpeed=5f;
    public GameObject player;
    Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
       cameraTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = player.transform.position - cameraTransform.forward * 11f + cameraTransform.up * 2f;
        float smoothSpeed = 10f;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
