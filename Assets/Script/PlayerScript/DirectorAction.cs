using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

//���׸ӽ��� �����ϰ� �ʹ�


public class DirectorAction : MonoBehaviour
{
    PlayableDirector pd;
    public Camera targetCam;

    // Start is called before the first frame update
    void Start()
    {
        //Director ������Ʈ�� ���� �ִ� PlayableDirector ������Ʈ�� �����´�.
        pd = GetComponent<PlayableDirector>();
        //Ÿ�Ӷ����� �����Ѵ�
        pd.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //���� �������� �ð��� ��ü �ð��� ũ�ų� ������ (����ð��� �� �Ǹ�)
        if(pd.time >= pd.duration)
        {
            //���� ���� ī�޶� ŸŶ ī�޶� (���׸ӽſ� Ȱ���ϴ� ī�޶�) ���
            //��� �ϱ� ���� ���׸ӽ� �극���� ��Ȱ��ȭ�϶�.

            if (UnityEngine.Camera.main == targetCam)
            {
                targetCam.GetComponent<CinemachineBrain>().enabled = false;
            }
            //���׸ӽſ� ����� ī�޶� ��Ȱ��ȭ�϶�;
            targetCam.gameObject.SetActive(false);

            //Director �ڽ��� ��Ȱ��ȭ�϶�
            gameObject.SetActive(false);
        }
    }
}
