using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject gameStartUI;
    public GameObject gamingUI;
    public GameObject gameEndUI;


    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
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
