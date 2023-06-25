using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCoin : MonoBehaviour
{
    float speed = 5f;
    Vector3 sum;
    Vector3 dir;
    public bool isBoxCoin=true;
    bool istrig;
    // Start is called before the first frame update
    void Start()
    {
        sum = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        
        transform.Rotate(0, 3, 0);

        if (isBoxCoin)
        {
            if (transform.position.y - sum.y < 2)
            {
                dir = Vector3.up * speed * Time.deltaTime;
                transform.position += dir;
            }
            else
            {
                if (istrig) return;
                istrig = true;
                Destroy(gameObject, 0.3f);
                UIManager.instance.COIN++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isBoxCoin)
        {
            UIManager.instance.COIN++;
            Destroy(gameObject);
        }
    }
}
