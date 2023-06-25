using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class _ : MonoBehaviour
{
    public GameObject vfx;
    bool istrig;
    public GameObject courseClearUi;

    // Start is called before the first frame update
    void Start()
    {
        courseClearUi.SetActive(false);
        vfx.SetActive(false);

    }

    float currentTime = 0f;
    public float TargetTime = 6f;
    // Update is called once per frame
    void Update()
    {
        if (DirectorAction.instance.isgoal)
        {
            currentTime += Time.deltaTime;
            if (currentTime > TargetTime)
            {
                courseClearUi.SetActive(true);
                if (istrig) return;
                istrig = true;
                vfx.transform.position = GameManager.instance.currentMario.transform.position;
                vfx.SetActive(true);
            }
        }
    }
}
