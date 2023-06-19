using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCoin : MonoBehaviour
{
    public bool outblock;
    public float speed = 5f;
    bool giveCoin =true;
    Vector3 sum;
    Vector3 dir;
    UIManager coinGet;


    // Start is called before the first frame update
    void Start()
    {
        GameObject UIManager = GameObject.Find("UIManager");
        coinGet = UIManager.GetComponent<UIManager>();
        sum = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.Rotate(0, 3, 0);

        if (!outblock)
        {
            if (transform.position.y - sum.y < 2)
            {
                dir = Vector3.up * speed * Time.deltaTime;
                transform.position += dir;
            }
            else
            {
                if (giveCoin)
                {
                    coinGet.COIN++;
                }
                giveCoin = false;
 
                Destroy(gameObject, 0.3f);
           
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Mario"))
        {
            coinGet.COIN++;
            Destroy(gameObject);
        }
    }
}
