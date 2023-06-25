using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Cinemachine;

//���׸ӽ��� �����ϰ� �ʹ�


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
        //Director ������Ʈ�� ���� �ִ� PlayableDirector ������Ʈ�� �����´�.
        pd = GetComponent<PlayableDirector>();
     
        //Ÿ�Ӷ����� �����Ѵ�

    }

    // Update is called once per frame
    void Update()
    {

        if (isgoal)
        {
            gamingUI.SetActive(false);
            //���� �������� �ð��� ��ü �ð��� ũ�ų� ������ (����ð��� �� �Ǹ�)
            if (pd.time >= pd.duration)
            {
                
                GameManager.instance.gameEndUI.SetActive(true);
                GameManager.instance.gamingUI.SetActive(false);
                courseClearUi.SetActive(false);

            }
        }



    }
}
