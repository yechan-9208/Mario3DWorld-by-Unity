using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushBox : MonoBehaviour
{

    #region 변수 선언
    public float countjump = 3f;
    public GameObject box1;
    public GameObject box2;
    public GameObject mushRoom;
    public bool check_pow = true;
    public bool isTrigAnim;
    bool isDropDown;
    bool istrig;
    #endregion

    #region 시작과 업데이트
    void Start()
    {
        box1.SetActive(true);
        box2.SetActive(false);
        if (mushRoom != null)
        {
            mushRoom.SetActive(false);
        }
    }

    private void Update()
    {

    }
    #endregion

    #region 충돌 감지
    private void OnTriggerEnter(Collider other)
    {
        if (box1.activeSelf) // 박스가 active false가 됐다면 더이상 작동하지 않기로
        {
            if (check_pow) // 만약 박스가 pow박스에의해 작동되었는지 (박스가 active false가 되기전에 추가 충돌에 대한 방지)
            {


                if (other.gameObject.name.Contains("Pow"))
                {
                    check_pow = false;
                    countjump = 0;

                    if (mushRoom != null)
                    {
                        mushRoom.SetActive(true);
                    }

                    Movebox();
                }
                else if (other.gameObject.name.Contains("Head"))
                {
                    if (gameObject.name.Contains("Pow"))
                    {
                        countjump = 0;

                        if (box1.activeSelf)
                        {
                            Movebox();
                        }
                    }
                    else
                    {
                        if (mushRoom != null)
                        {
                            mushRoom.SetActive(true);
                        }

                        countjump -= 1;
                        Movebox();
                    }
                }

                else if (other.gameObject.name.Contains("Foot") && MPlayer.instance.isDropDown == true)
                {

                    isDropDown = true;
                    if (gameObject.name.Contains("Pow"))
                    {
                        countjump = 0;

                        if (box1.activeSelf)
                        {
                            Movebox();
                        }
                    }
                    else
                    {
                        if (mushRoom != null)
                        {
                            mushRoom.SetActive(true);
                        }

                        countjump -= 1;
                        Movebox();
                    }

                }
            }

        }
    }

    void Movebox()
    {

        istrig = false;


        if (countjump < 0)
        {
            return;
        }


        if (isDropDown)
        {
            Down();
        }
        else
        {
            Up();
        }



    }

    void TurnSetDown()
    {
        if (istrig) return;
        else
        {
            istrig = true;
        }

        if (countjump <= 0)
        {
            box1.SetActive(false);
            box2.SetActive(true);

        }

        if (isDropDown)
        {
            Up();
        }
        else
        {
            Down();
        }


    }
    #endregion


    void Up()
    {


        iTween.MoveBy(gameObject, iTween.Hash(
            "y", 0.5,
            "easeType", iTween.EaseType.easeOutExpo,
            "delay", 0.1f,
            "speed", 10,
            "oncompletetarget", gameObject,
            "oncomplete", nameof(TurnSetDown)));

    }

    void Down()
    {
        iTween.MoveBy(gameObject, iTween.Hash(
            "y", -0.5,
            "easeType", iTween.EaseType.easeOutExpo,
            "delay", 0.1f,
            "speed", 4,
            "oncompletetarget", gameObject,
            "oncomplete", nameof(TurnSetDown)));
    }

}


