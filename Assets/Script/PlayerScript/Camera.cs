using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform target;
    public Vector3 offset = Vector3.up;
    public Camera mainCamera;
    private Transform selfTransform;

    [SerializeField]
    private GameObject go_Target;

    [SerializeField]

    private float speed;

    private Vector3 difValue;
    private static Camera main;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("GameObject").transform;
        selfTransform = transform;
        mainCamera = Camera.main;

        difValue = transform.position - go_Target.transform.position;
        difValue = new Vector3(Mathf.Abs(difValue.x), Mathf.Abs(difValue.y), Mathf.Abs(difValue.z));
    }

    // Update is called once per frame
    void Update()
    {
        selfTransform.position = mainCamera.WorldToViewportpoint(target.position + (-1 * offset));
        this.transform.position = Vector3.Lerp(this.transform.position, go_Target.transform.position + difValue, speed);
    }

    private Vector3 WorldToViewportpoint(Vector3 vector3)
    {
        throw new NotImplementedException();
    }

    internal Vector3 WorldToViewportPoint(Vector3 position)
    {
        throw new NotImplementedException();
    }

    internal Vector3 ViewportToWorldPoint(Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}