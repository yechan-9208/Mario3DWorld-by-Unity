using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public static UIManager instance = null;
    private void Awake()
    {
        instance = this;
    }


    int coin;
    public TextMeshProUGUI CoinScore;
    int time;
    public TextMeshProUGUI TimeScore;

    float currentTime = 0;

    public int COIN
    {
        get { return coin; }
        set 
        { 
            coin = value;
            CoinScore.text = ""+coin;
        }
    }

    public int TIME
    {
        get { return time; }
        set
        {
            time = value;
            TimeScore.text = "" + time;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        COIN = 0;
        TIME = 400;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime>=1f)
        {
            TIME--;
            currentTime = 0;
        }
    }



}
