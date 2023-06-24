using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fLeafMove : MonoBehaviour
{
    public GameObject flowerLeafR;
    public Transform[] leafR;
    [Range(0,1)]
    public float valuef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        iTween.PutOnPath(flowerLeafR, leafR, valuef);
        Destroy(flowerLeafR);
    }
    private void OnDrawGizmos()
    {


        iTween.DrawPath(leafR,Color.green);
        
    }
}
