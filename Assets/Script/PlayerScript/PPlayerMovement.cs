using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPlayerMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //a : -1,d : 1, 누르지 않았을 경우 : 0
        float v = Input.GetAxis("Vertical"); // s : -1, w : 1, 누르지 않았을 경우 : 0
        //2. 방향을 만든다.
        Vector3 dirH = transform.right * h;
        Vector3 dirV = transform.forward * v;
        Vector3 dir = dirH + dirV;

        Vector3 movementDirection = new Vector3(h, 0, v);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
        }
    }
}
