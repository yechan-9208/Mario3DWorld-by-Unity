using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Cinemachine;

//씨네머신을 제어하고 싶다


public class DirectorAction : MonoBehaviour
{

    public PlayableDirector pd;
    public GameObject camarea;
    Camera targetCam;
    public bool isgoal;
    public GameObject gamingUI;
    public GameObject courseClearUi;

    public static DirectorAction instance;

    private void Awake()
    {
        instance=this;
    }


 

    // Start is called before the first frame update
    void Start()
    {
    
        targetCam = camarea.GetComponent<Camera>();
        camarea.SetActive(false);
        //Director 오브젝트가 갖고 있는 PlayableDirector 컴포넌트를 가져온다.
        pd = GetComponent<PlayableDirector>();
     
        //타임라인을 실행한다

    }

    // Update is called once per frame
    void Update()
    {

        if (isgoal)
        {
            gamingUI.SetActive(false);
            //현재 진행중인 시간이 전체 시간과 크거나 같으면 (재생시간이 다 되면)
            if (pd.time >= pd.duration)
            {
                
                GameManager.instance.gameEndUI.SetActive(true);
                GameManager.instance.gamingUI.SetActive(false);
                courseClearUi.SetActive(false);

            }
        }



    }
}
