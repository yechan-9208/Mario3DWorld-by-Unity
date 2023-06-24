using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject gameStartUI;
    public GameObject gamingUI;
    public GameObject gameEndUI;
    public GameObject bigMairo;
    public GameObject smallMario;
    public Transform spwanPosion;
    


    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void BigToSmallMario()
    {
        smallMario.transform.position = bigMairo.transform.position;
        bigMairo.SetActive(false);
        
        StartCoroutine(MyCoroutine());
    }

    public void gameOver()
    {
        smallMario.SetActive(false);
        bigMairo.transform.position = spwanPosion.transform.position;
        bigMairo.SetActive(true);
    }

    private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        smallMario.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        gameStartUI.SetActive(true);
        gameEndUI.SetActive(false);
        gamingUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMyRePLAY()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMyQuit()
    {
        //Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

}
