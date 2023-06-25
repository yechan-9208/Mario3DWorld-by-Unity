using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBox : MonoBehaviour
{

    #region ���� ����
    public float countjump = 3f;
    public GameObject box1;
    public GameObject box2;
    public GameObject Coin;
    public bool check_pow = true;
    public bool isTrigAnim;
    bool isDropDown;
    bool istrig;
    #endregion

    #region ���۰� ������Ʈ
    void Start()
    {
        box1.SetActive(true);
        box2.SetActive(false);
        if (Coin != null)
        {
            Coin.SetActive(false);
        }
    }

    private void Update()
    {

    }
    #endregion

    #region �浹 ����
    private void OnTriggerEnter(Collider other)
    {
        if (box1.activeSelf) // �ڽ��� active false�� �ƴٸ� ���̻� �۵����� �ʱ��
        {
            if (check_pow) // ���� �ڽ��� pow�ڽ������� �۵��Ǿ����� (�ڽ��� active false�� �Ǳ����� �߰� �浹�� ���� ����)
            {
                if (other.gameObject.name.Contains("Pow"))
                {
                    check_pow = false;
                    countjump = 0;

                    if (Coin != null)
                    {
                        Coin.SetActive(true);
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
                        if (Coin != null)
                        {
                            Coin.SetActive(true);
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
                        if (Coin != null)
                        {
                            Coin.SetActive(true);
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
        if (isTrigAnim) return;

        isTrigAnim = true;
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

        isTrigAnim = false;
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


