using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject Warpbox;
    public GameObject WarpboxLocked;
    public bool WarpIn = true;
    public bool justone = true;
    public GameObject WarpPosion;
    public GameObject Mario;


    void Start()
    {
        trig(Warpbox, WarpboxLocked, WarpIn);
    }


    void Update()
    {
        Mario = GameManager.instance.currentMario;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Mario"))
        {
            if (justone)
            {
                WarpIn = !WarpIn;
                trig(Warpbox, WarpboxLocked, WarpIn);
                StartCoroutine(Coroutine());
                justone = false;
            }
        }
    }

    void trig(GameObject box1, GameObject box2, bool WarpIn)
    {
        if (WarpIn)
        {
            box1.SetActive(true);
            box2.SetActive(false);
        }
        else
        {
            box1.SetActive(false);
            box2.SetActive(true);
        }
    }

    IEnumerator Coroutine()
    {
        Mario.SetActive(false);
        yield return new WaitForSeconds(2f);
        Mario.transform.position = WarpPosion.transform.position;
        GameManager.instance.spwanPosion.position = WarpPosion.transform.position;
        Mario.SetActive(true);
    
      
    }
}
