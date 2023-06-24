using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Animator anim;
    bool isSave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isSave == true) return;
        transform.Find("NoSave").gameObject.SetActive(false);
        transform.Find("SaveMario").gameObject.SetActive(true);
        GameManager.instance.spwanPosion.position = gameObject.transform.position;
        anim.SetTrigger("Check");
        isSave = true;
    }
}
