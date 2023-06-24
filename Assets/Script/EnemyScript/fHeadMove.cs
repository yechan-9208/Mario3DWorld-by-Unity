using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fHeadMove : MonoBehaviour
{
    public GameObject flowerHead;
    public Transform[] Head;
    [Range(0, 1)]
    public float valuef;
    float tempTime;
    // Start is called before the first frame update
    void Start()
    {
        //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath()))
    }

    // Update is called once per frame
    void Update()
    {
        iTween.PutOnPath(flowerHead, Head, valuef);
        //iTween.MoveTo(gameObject, iTween.Hash(
        //    "position", targetPoint.position,
        //    "speed", moveSpeed,
        //    "easetype", iTween.EaseType.linear,
        //    "oncomplete", "DestroyObject"
        //));
        Destroy(flowerHead);

    }
    private void OnDrawGizmos()
    {
        iTween.DrawPath(Head, Color.blue);

    }
}
