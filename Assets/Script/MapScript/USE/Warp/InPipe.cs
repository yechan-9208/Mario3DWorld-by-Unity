using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPipe : MonoBehaviour
{
    Vector3 dir;
    public GameObject Mario;
    public GameObject Blocking;
    public bool Warp;
    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        dir.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Warp)
        {
            if(Blocking!= null)
            {
                Blocking.SetActive(true);
            }
            
            currentTime += Time.deltaTime;
            if (currentTime <= 1f)
            {
                transform.position += Vector3.up * 2 * Time.deltaTime;
            }
            if (currentTime <= 1.5f)
            {
                Mario.transform.position += Vector3.up * 2 * Time.deltaTime;
            }
            if(currentTime>=1.5f)
            {
                Mario.GetComponent<CharacterController>().enabled = true;
                transform.position += Vector3.down * 2 * Time.deltaTime;
            }
            if(currentTime >3f)
            {
                Destroy(gameObject);
            }
        }
        }
    }

