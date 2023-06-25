using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fLeafMove : MonoBehaviour
{
    public GameObject flowerLeafR;
    public Transform[] leafR;
    public GameObject obj1, obj2, obj3;
    
    [Range(0,1)]
    public float valuef;
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveBy(gameObject, iTween.Hash("x", 10, "y", 10, "z", 10, "easyType", iTween.EaseType.linear));



    }

    // Update is called once per frame
    void Update()
    {
        
        //iTween.PutOnPath(flowerLeafR, leafR, valuef);
        //Destroy(flowerLeafR);
    }
    private void OnDrawGizmos()
    {


        iTween.DrawPath(leafR,Color.green);
        
    }
}
