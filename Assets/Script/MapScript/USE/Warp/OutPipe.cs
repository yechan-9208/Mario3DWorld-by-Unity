using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutPipe : MonoBehaviour
{
    public GameObject WarpPosion;
    public GameObject Mario;
    bool inpipe;
    float currtTime = 0;
    float vecY;
    Vector3 dir;
    public bool Horizon;
    public bool Vertical;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        vecY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Mario = GameManager.instance.currentMario;
        anim = GameManager.instance.anim;
        if (inpipe)
        {

            currtTime += Time.deltaTime;
            Mario.GetComponent<CharacterController>().enabled = false;

 
            dir = Mario.transform.position;
            dir.y = vecY-1;
            Mario.transform.position = dir;
            if (Horizon)
                Mario.transform.position += Vector3.forward * Time.deltaTime;
            if (Vertical)
                Mario.transform.position += Vector3.right * Time.deltaTime;

            if (currtTime>1f)
            {
                Mario.transform.position = WarpPosion.transform.position;
                WarpPosion.GetComponent<InPipe>().Warp=true;
  
                inpipe = false;
            }

        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Mario"))
        {
            Mario = GameManager.instance.currentMario;
            inpipe = true;
            anim.SetBool("isPipe", true);
        }
    }

    //IEnumerator Coroutine()
    //{
    //    Mario.SetActive(false);
    //    yield return new WaitForSeconds(1f);
    //    Mario.transform.position = WarpPosion.transform.position;
    //    Mario.SetActive(true);

    //}
}
